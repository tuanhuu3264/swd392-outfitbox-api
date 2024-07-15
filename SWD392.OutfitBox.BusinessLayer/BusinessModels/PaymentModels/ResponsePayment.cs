using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.BusinessModels.PaymentModels
{

    public class ResponsePayment
    {
        public string? ResponseCodeMessage { get; set; }
        public string? TransactionStatusMessage { get; set; }
        public VnPayResponse? VnPayResponse { get; set; }

    }
    public class VnPayResponse
    {
        public string? BankTranNo { get; set; }
        public string? PayDate { get; set; }
        public string? OrderInfo { get; set; }
        public string? ResponseCode { get; set; }
        public string? TransactionVNId { get; set; }
        public string? TransactionStatus { get; set; }
        public string? CardType { get; set; }
        public string? TxnRef { get; set; }
        public long Amount { get; set; }
        public string? BankCode { get; set; }
    }
}
