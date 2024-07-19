using Abp.Runtime.Caching;
using AutoMapper;
using FirebaseAdmin.Messaging;
using Newtonsoft.Json;
using StackExchange.Redis;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.BusinessModels.PaymentModels;
using SWD392.OutfitBox.BusinessLayer.Enum;

using SWD392.OutfitBox.BusinessLayer.Services.PaymentService;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.FirebaseCloudMessaging;
using SWD392.OutfitBox.DataLayer.UnitOfWork;
using SWD392.OutfitBox.DataLayer.VNPay;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDatabase _cache;
        private readonly ConnectionMultiplexer _redis;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _redis = ConnectionMultiplexer.Connect("outfit4rent.online:6379");
            _cache = _redis.GetDatabase();
        }
        public async Task<ResponsePayment> GetInformationPayment(VNPayModel dto)
        {

            string vnp_HashSecret = "GCLECYOCZYQLDTIUGHGWZAWPNALXPLOJ";

            var vnpayData = dto.urlResponse.Split("?")[1];
            VNPayHelper vnpay = new VNPayHelper();

            foreach (string s in vnpayData.Split("&"))
            {
                if (!string.IsNullOrEmpty(s) && s.StartsWith("vnp_"))
                {
                    vnpay.AddResponseData(s.Split("=")[0], s.Split("=")[1]);
                }
            }
            string vnpayTranId = vnpay.GetResponseData("vnp_TransactionNo");
            string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
            string orderInfo = vnpay.GetResponseData("vnp_OrderInfo").Replace("+", " ").Replace("%3A", ":");
            String vnp_SecureHash = vnpay.GetResponseData("vnp_SecureHash");
            String TerminalID = vnpay.GetResponseData("vnp_TmnCode");
            long vnp_Amount = Convert.ToInt64(vnpay.GetResponseData("vnp_Amount")) / 100;
            String bankCode = vnpay.GetResponseData("vnp_BankCode");
            string transactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");
            string txnRef = vnpay.GetResponseData("vnp_TxnRef");
            string responseCode = vnpay.GetResponseData("vnp_ResponseCode");
            string bankTranNo = vnpay.GetResponseData("vnp_BankTranNo");
            string cardType = vnpay.GetResponseData("vnp_CardType");
            string payDate = vnpay.GetResponseData("vnp_PayDate");
            string hashSecret = vnpay.GetResponseData("vnp_HashSecret");

            var check = await _unitOfWork._transactionRepository.GetTransactionsByVNPayCode(vnpayTranId);
            if (check != null) { vnp_ResponseCode = "07"; transactionStatus = "02"; 
            }
            VnPayResponse response = new VnPayResponse()
            {
                TransactionVNId = vnpayTranId,
                OrderInfo = orderInfo,
                Amount = vnp_Amount,
                BankCode = bankCode,
                BankTranNo = bankTranNo,
                CardType = cardType,
                PayDate = payDate,
                ResponseCode = responseCode,
                TransactionStatus = transactionStatus,
                TxnRef = txnRef,
                UserId = int.Parse(orderInfo)
            };
            if (vnp_ResponseCode == "00" && transactionStatus == "00")
            {
                using (_unitOfWork.BenginTransaction())
                {
                    await _unitOfWork.CommitTransaction();
                    try
                    {
                        var wallet = await _unitOfWork._walletRepository.GetWalletByCode(bankCode, int.Parse(orderInfo));
                        if (wallet.Id == 0)
                        {
                            wallet = new Wallet
                            {
                                WalletCode = bankCode,
                                WalletName = bankTranNo,
                                WalletPassword = "123456",
                                OTP = 123456,
                                Status = 1,
                                CustomerId = response.UserId.Value,

                            };
                            wallet = await _unitOfWork._walletRepository.CreateWallet(response.UserId.Value, wallet);
                        }
                        var deposit = new Deposit()
                        {
                            CustomerId = response.UserId.Value,
                            AmountMoney = vnp_Amount / 25000,
                            Date = DateTime.NowAddHours(7),
                            Type = "Payment",
                        };
                        var result = await _unitOfWork._depositRepository.CreateDeposit(deposit);
                        var transaction = new Transaction()
                        {
                            DateTransaction = DateTime.Now.AddHours(7),
                            Amount = vnp_Amount / 25000,
                            VNPayID = vnpayTranId,
                            Status = 1,
                            Paymethod = "Online",
                            WalletId = wallet.Id,
                            DepositId = result.Id
                        };
                        transaction = await _unitOfWork._transactionRepository.CreateTransaction(transaction);
                        var customer = await _unitOfWork._customerRepository.GetCustomerById(response.UserId.Value);
                        customer.MoneyInWallet = customer.MoneyInWallet + vnp_Amount / 25000;
                        await _unitOfWork._customerRepository.UpdateCustomer(customer);
                        Message message = new Message();
                        var serializedModel = _cache.StringGet(customer.Id.ToString());
                        if (serializedModel.HasValue)
                        {
                            var deviceModel = JsonConvert.DeserializeObject<DeviceTokenModels>(serializedModel);
                            message.Token = deviceModel.DeviceToken;
                        }
                        message.Notification = new Notification()
                        {
                            Title = "Recharge successfully",
                            Body = $"The system successfully recharge {customer.MoneyInWallet} to your wallet"
                        };
                        if (message.Token != null) FirebaseCloudMessagingHelper.SendNotificationByMessage(message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        await _unitOfWork.RollbackTransaction();
                    }
                }
            }
            var responseCodeMessage = ReturnedErrorMessageResponseCode(vnp_ResponseCode);
            var transactionStatusMessage = ReturnedErrorMessageTransactionStatus(transactionStatus);
            ResponsePayment payment = new ResponsePayment()
            {
                ResponseCodeMessage = responseCodeMessage,
                TransactionStatusMessage = transactionStatusMessage,
                VnPayResponse = response
            };
            return payment;
        }

        public async Task<string> CallAPIPayByUserId(int userId, double money)
        {
            try
            {
                var user = await _unitOfWork._customerRepository.GetCustomerById(userId);
                if (user == null) {
                    throw new Exception("Not Found this customer");
                }
                string vnp_ReturnUrl = "https://ackerman.fun/payment";
                string vnp_Url = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html";
                string vnp_TmnCode = "F8V1A5TK";
                string vnp_HashSecret = "GCLECYOCZYQLDTIUGHGWZAWPNALXPLOJ";
                if (string.IsNullOrEmpty(vnp_TmnCode) || string.IsNullOrEmpty(vnp_HashSecret))
                {
                    throw new Exception("Merchant code or secret key is missing.");
                }
                var amount =(money*2500000).ToString();
                var vnp_TxnRef = $"{userId}{userId}{DateTime.Now.ToString("HHmmss")}";
                var vnp_Amount = amount;

                var vnpay = new VNPayHelper();
                vnpay.AddRequestData("vnp_Version", "2.1.0");
                vnpay.AddRequestData("vnp_Command", "pay");
                vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
                vnpay.AddRequestData("vnp_Amount", vnp_Amount);
                vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.AddMinutes(-20).ToString("yyyyMMddHHmmss"));
                vnpay.AddRequestData("vnp_CurrCode", "VND");
                vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress());
                vnpay.AddRequestData("vnp_Locale", "vn");
                vnpay.AddRequestData("vnp_OrderInfo", $"{user.Id}");
                vnpay.AddRequestData("vnp_OrderType", "order");
                vnpay.AddRequestData("vnp_ReturnUrl", vnp_ReturnUrl);
                vnpay.AddRequestData("vnp_TxnRef", vnp_TxnRef);
                vnpay.AddRequestData("vnp_ExpireDate", DateTime.Now.AddDays(2).ToString("yyyyMMddHHmmss"));
                string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
                return paymentUrl;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred during payment: {ex.Message}");
            }
        }
        private string ReturnedErrorMessageTransactionStatus(string code)
        {
            switch (code)
            {
                case "00": return "Giao dịch thành công";
                case "01": return "Giao dịch chưa hoàn tất";
                case "02": return "Giao dịch bị lỗi";
                case "04": return "Giao dịch đảo (Khách hàng đã bị trừ tiền tại Ngân hàng nhưng GD chưa thành công ở VNPAY)";
                case "05": return "VNPAY đang xử lý giao dịch này (GD hoàn tiền)";
                case "06": return "VNPAY đã gửi yêu cầu hoàn tiền sang Ngân hàng (GD hoàn tiền)";
                case "07": return "Giao dịch bị nghi ngờ gian lận";
                case "09": return "GD Hoàn trả bị từ chối";
                default: return "Mã lỗi không hợp lệ";
            }
        }
        private string ReturnedErrorMessageResponseCode(string code)
        {
            switch (code)
            {
                case "00": return "Giao dịch thành công";
                case "07": return "Trừ tiền thành công. Giao dịch bị nghi ngờ (liên quan tới lừa đảo, giao dịch bất thường).";
                case "09": return "Giao dịch không thành công do: Thẻ/Tài khoản của khách hàng chưa đăng ký dịch vụ InternetBanking tại ngân hàng.";
                case "10": return "Giao dịch không thành công do: Khách hàng xác thực thông tin thẻ/tài khoản không đúng quá 3 lần.";
                case "11": return "Giao dịch không thành công do: Đã hết hạn chờ thanh toán. Xin quý khách vui lòng thực hiện lại giao dịch.";
                case "12": return "Giao dịch không thành công do: Thẻ/Tài khoản của khách hàng bị khóa.";
                case "13": return "Giao dịch không thành công do Quý khách nhập sai mật khẩu xác thực giao dịch (OTP). Xin quý khách vui lòng thực hiện lại giao dịch.";
                case "24": return "Giao dịch không thành công do: Khách hàng hủy giao dịch.";
                case "51": return "Giao dịch không thành công do: Tài khoản của quý khách không đủ số dư để thực hiện giao dịch.";
                case "65": return "Giao dịch không thành công do: Tài khoản của Quý khách đã vượt quá hạn mức giao dịch trong ngày.";
                case "75": return "Ngân hàng thanh toán đang bảo trì.";
                case "79": return "Giao dịch không thành công do: KH nhập sai mật khẩu thanh toán quá số lần quy định. Xin quý khách vui lòng thực hiện lại giao dịch.";
                case "99": return "Các lỗi khác (lỗi còn lại, không có trong danh sách mã lỗi đã liệt kê).";
                default: return "Mã lỗi không hợp lệ";
            }
        }


    }
}