using Abp.Application.Services.Dto;
using Abp.Domain.Uow;
using Abp.Extensions;
using AutoMapper;
using Azure.Core;
using Castle.Core.Resource;
using FirebaseAdmin.Messaging;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using StackExchange.Redis;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.BusinessModels.PaymentModels;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.FirebaseCloudMessaging;
using SWD392.OutfitBox.DataLayer.Streaming.ProducerMessage;
using SWD392.OutfitBox.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using IUnitOfWork = SWD392.OutfitBox.DataLayer.UnitOfWork.IUnitOfWork;

namespace SWD392.OutfitBox.BusinessLayer.Services.UserPackageService
{
    public class CustomerPackageService : ICustomerPackageService
    {
        private readonly IUnitOfWork _unitOfWork;

        private IMapper _mapper;
        private readonly IDatabase _cache;
        private readonly ConnectionMultiplexer _redis;
        public CustomerPackageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _redis = ConnectionMultiplexer.Connect("outfit4rent.online:6379");
            _cache = _redis.GetDatabase();
        }
        public async Task<CustomerPackageModel> ChangeStatus(int id, int status)
        {
            using (var transaction = _unitOfWork.BenginTransaction())
            {
                try
                {
                    var customerPackageModel = await _unitOfWork._customerPackageRepository.GetCustomerPackgageAndItemsbyId(id);
                    if (customerPackageModel == null) throw new Exception("Not Found this CustomerPackage");
                    if (customerPackageModel.Status == status) throw new Exception("This CustomerPackage already has this status");
                    Message message = new Message();
                    var serializedModel = _cache.StringGet(customerPackageModel.CustomerId.ToString());
                    if (serializedModel.HasValue)
                    {
                        var deviceModel = JsonConvert.DeserializeObject<DeviceTokenModels>(serializedModel);
                        message.Token = deviceModel.DeviceToken;
                    }
                    var itemInCustomerPackageModel = await _unitOfWork._itemsInUserPackageRepository.GetByUserPackageId(customerPackageModel.Id);

                    //-1 - canceled order
                    // 0 - pending approval
                    // 1 - renting
                    // 2 - rental expired

                    if (customerPackageModel.Status == 0 && status == 1)
                    {
                        customerPackageModel.Status = status;
                        itemInCustomerPackageModel.ForEach(x => x.Status = 1);

                        foreach (var item in itemInCustomerPackageModel)
                        {
                            await _unitOfWork._itemsInUserPackageRepository.UpdateItem(item);
                        }

                        var updatedOrder = await _unitOfWork._customerPackageRepository.SaveAsyn(customerPackageModel);

                        await _unitOfWork.SaveChangesAsync();
                        await _unitOfWork.CommitTransaction();

                        message.Notification = new Notification()
                        {
                            Title = "Order is accepted.",
                            Body = $"The Order #{customerPackageModel.Id} is accepted. The order will be gived to you soon."
                        };
                    
                        if (message.Token != null) FirebaseCloudMessagingHelper.SendNotificationByMessage(message);
                        return _mapper.Map<CustomerPackageModel>(updatedOrder);
                    }
                    else if (customerPackageModel.Status == 0 && status == -1)
                    {
                        if (customerPackageModel.Items != null)
                        {
                            foreach (var item in customerPackageModel.Items)
                            {
                                var product = await _unitOfWork._productRepository.GetById(item.ProductId);
                                if (product != null)
                                {
                                    product.Quantity += item.Quantity;
                                    await _unitOfWork._productRepository.UpdateProduct(product);
                                }
                            }
                        }

                        customerPackageModel.Status = status;
                        itemInCustomerPackageModel.ForEach(x => x.Status = -1);

                        var updatedOrder = await _unitOfWork._customerPackageRepository.SaveAsyn(customerPackageModel);



                        var customer = await _unitOfWork._customerRepository.GetCustomerById(customerPackageModel.CustomerId);
                        var wallet = (await _unitOfWork._walletRepository.GetAllWalletsByUserId(customer.Id)).First(x => x.WalletName == "Outfit4rent");

                        var deposit = new Deposit()
                        {
                            AmountMoney = (double)customerPackageModel.TotalDeposit,
                            CustomerId = customer.Id,
                            Date = DateTime.Now,
                            Type = "Return Money As Canceling Order",
                            Transactions = new List<Transaction>()
                            {
                                new Transaction()
                                {
                                    WalletId=wallet.Id,
                                    DateTransaction=DateTime.Now,
                                    Content="Return Money Order"+customerPackageModel.OrderCode,
                                    Amount=(double)customerPackageModel.TotalDeposit,
                                    Paymethod="Online",
                                    Status=1,
                                }
                            }
                        };
                        await _unitOfWork._depositRepository.CreateDeposit(deposit);
                        if (customer != null)
                        {
                            customer.MoneyInWallet += (long)(customerPackageModel.TotalDeposit + customerPackageModel.Price);
                            await _unitOfWork._customerRepository.UpdateCustomer(customer);
                        }

                        await _unitOfWork.SaveChangesAsync();
                        await _unitOfWork.CommitTransaction();
                        message.Notification = new Notification()
                        {
                            Title = "Order is cancelled.",
                            Body = $"The Order #{customerPackageModel.Id} is cancelled. The deposit will be returned to you."
                        };
                        if (message.Token != null) FirebaseCloudMessagingHelper.SendNotificationByMessage(message);

                        Task.WhenAll(
                           ProducerMessage.ProductUpdateRedisMessage<List<CustomerPackageModel>>("delete-customer-packages-by-customerId", "delete", null, $"customer-packages-customer:{customerPackageModel.CustomerId}"),
                           ProducerMessage.ProductUpdateRedisMessage<List<CustomerPackageModel>>("delete-customer-packages-by-customerId", "delete", null, $"customer-packages-status:{status}"),
                           ProducerMessage.ProductUpdateRedisMessage<List<CustomerPackageModel>>("delete-customer-packages-by-customerId", "delete", null, $"customer-packages-status:{customerPackageModel.Status}"),
                           ProducerMessage.ProductUpdateRedisMessage<CustomerPackageModel>("delete-customer-packages-byId" + customerPackageModel.Id, "delete", null, $"customer-packages-id:{customerPackageModel.Id}")

                           );
                        return _mapper.Map<CustomerPackageModel>(updatedOrder);
                    }
                    else
                    {
                        throw new Exception("Invalid status transition");
                    }
                }
                catch (Exception ex)
                {
                    await _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<CustomerPackageModel> CreateCustomerPackage(CustomerPackageModel customerPackageModel, int walletId)
        {
            var customerPackage = _mapper.Map<CustomerPackage>(customerPackageModel);

            var package = await _unitOfWork._packageRepository.GetPackageById(customerPackage.PackageId);
            if (package == null) throw new Exception("There is no package that has id: " + customerPackage.PackageId);

            var user = await _unitOfWork._customerRepository.GetCustomerById(customerPackage.CustomerId);
            if (user == null) throw new Exception("There is no customer that has id: " + customerPackage.CustomerId);

            var wallet = await _unitOfWork._walletRepository.GetWalletById(walletId);
            if (wallet == null) throw new Exception("There is no wallet that has id: " + walletId);

            customerPackage.CreatedAt = DateTime.Now;
            customerPackage.PackageName = package.Name;
            customerPackage.DateTo = customerPackage.DateFrom.AddDays(package.AvailableRentDays);
            customerPackage.Price = package.Price;
            customerPackage.Status = 0;
            customerPackage.TotalDeposit = 0;

            // Check tổng số lượng sản phẩm phải nhỏ hơn tổng số lượng quy định 
            var numberProducts = customerPackageModel.ItemInUsers.Sum(x => x.Quantity);
            if (numberProducts > package.NumOfProduct) throw new Exception("Number of products is over required number");

            // Check số lượng sản phẩm có phù hợp không
            if (customerPackage.Items != null)
            {
                foreach (var item in customerPackage.Items)
                {
                    var product = await _unitOfWork._productRepository.GetById(item.ProductId);
                    if (product == null) throw new Exception($"Product with ID {item.ProductId} not found.");
                    if (item.Quantity > product.Quantity) throw new Exception($"The quantity of product {product.Name} is over available number");
                }
            }

            // Check số lượng category có phù hợp không 
            var categoryPackages = await _unitOfWork._categoryPackageRepository.GetAllCategoryPackagesByPackageId(package.Id);
            var categoryPackage = categoryPackages.ToDictionary(cp => cp.CategoryId, cp => cp.MaxAvailableQuantity);

            if (customerPackage.Items != null)
            {
                foreach (var item in customerPackage.Items)
                {
                    var product = await _unitOfWork._productRepository.GetById(item.ProductId);
                    if (product == null) throw new Exception($"Product with ID {item.ProductId} not found.");

                    if (!categoryPackage.TryGetValue(product.IdCategory, out var maxQuantity))
                    {
                        throw new Exception($"Category with ID {product.IdCategory} is not required in package");
                    }

                    if (maxQuantity < item.Quantity)
                    {
                        var category = await _unitOfWork._categoryRepository.GetById(product.IdCategory);
                        if (category == null) throw new Exception($"Category with ID {product.IdCategory} not found.");
                        throw new Exception($"The quantity of category {category.Name} is over required number");
                    }
                    categoryPackage.Remove(product.IdCategory);
                    categoryPackage.Add(product.IdCategory, maxQuantity - item.Quantity);
                }
            }

            List<Product> products = new List<Product>();
            // Tính toán 
            if (customerPackage.Items != null)
            {
                foreach (var item in customerPackage.Items)
                {
                    var product = await _unitOfWork._productRepository.GetById(item.ProductId);
                    if (product == null) throw new Exception($"Product with ID {item.ProductId} not found.");
                    item.Status = 0;
                    item.Deposit = product.Deposit * item.Quantity*package.Price;
                    item.TornMoney = 0;
                    product.Quantity -= item.Quantity;

                    customerPackage.TotalDeposit +=product.Deposit * item.Quantity*package.Price;
                    await _unitOfWork._productRepository.UpdateProduct(product);
                }
            }

            if (wallet.WalletName == "Outfit4rent" && user.MoneyInWallet < (double)(customerPackage.Price + customerPackage.TotalDeposit))
                throw new Exception("User doesn't have enough money to check-out.");

            var deposite = new Deposit()
            {
                CustomerId = customerPackage.CustomerId,
                AmountMoney = (double)(customerPackage.Price + customerPackage.TotalDeposit),
                Date = DateTime.Now,
                Type = "Payment for rent"
            };

            using (var transaction = _unitOfWork.BenginTransaction())
            {
                try
                {
                    var createdDeposit = await _unitOfWork._depositRepository.CreateDeposit(deposite);
                    var createdTransaction = await _unitOfWork._transactionRepository.CreateTransaction(new Transaction()
                    {
                        Amount = createdDeposit.AmountMoney,
                        Content = $"Buy Order ",
                        DateTransaction = DateTime.Now,
                        DepositId = createdDeposit.Id,
                        Paymethod = wallet.WalletName,
                        WalletId = wallet.Id,
                        Status = 1,
                    });

                    customerPackage.TransactionId = createdTransaction.Id;
                    customerPackage.QuantityOfItems = customerPackageModel.ItemInUsers.Sum(x => x.Quantity);
                    var result = await _unitOfWork._customerPackageRepository.CreateUserPackage(customerPackage);
              
                    if (result != null)
                    {
                        Random random = new Random();
                        result.OrderCode = "O4R" + result.Id + random.Next(1000, 9999);
                        await _unitOfWork._customerPackageRepository.SaveAsyn(customerPackage);
                        foreach (var product in products)
                        {
                            await _unitOfWork._productRepository.UpdateProduct(product);
                        }

                        if (wallet.WalletName == "Outfit4rent")
                        {
                            user.MoneyInWallet -= (long)(customerPackage.Price + customerPackage.TotalDeposit);
                            await _unitOfWork._customerRepository.UpdateCustomer(user);
                        }
                    }

                    await _unitOfWork.CommitTransaction();
                    Task.WhenAll(
                           ProducerMessage.ProductUpdateRedisMessage<List<CustomerPackageModel>>("delete-customer-packages-by-customerId", "delete", null, $"customer-packages-customer:{customerPackageModel.CustomerId}"),
                           ProducerMessage.ProductUpdateRedisMessage<List<CustomerPackageModel>>("delete-customer-packages-by-customerId", "delete", null, $"customer-packages-status:{0}"),
                            FirebaseCloudMessagingHelper.SendNotificationToTopic("new-orders", "You have a new order.", "The order is created. Please to check! Order Id: " + result.Id)
                           );
                   
                    return _mapper.Map<CustomerPackageModel>(result);
                }
                catch (Exception ex)
                {
                    await _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
        }
        public async Task<List<CustomerPackageModel>> GetAllCustomerPackageByCustomerId(int customerId)
        {
            try
            {
                var cacheCustomerPackages = _cache.StringGet($"customer-packages-customer:{customerId}").ToString();
                var data = JsonConvert.DeserializeObject<List<CustomerPackageModel>>(cacheCustomerPackages);
                if (cacheCustomerPackages != null && cacheCustomerPackages.Any())
                {
                    return data;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            var result = await _unitOfWork._customerPackageRepository.GetCustomerPackageByCustomerId(customerId);
            foreach(var item in result)
            {
                foreach(var product in item.Items)
                {
                    product.Product = null;
                }
            }
            if (result.Any())
            {
              await  Task.WhenAll(
                   ProducerMessage.ProductUpdateRedisMessage<List<CustomerPackageModel>>("update-customer-packages-by-customerId" + customerId, "create", _mapper.Map<List<CustomerPackageModel>>(result), $"customer-packages-customer:{customerId}")
               );
            }
            return _mapper.Map<List<CustomerPackageModel>>(result);
        }

        public async Task<List<CustomerPackageModel>> GetCustomrPackagesByStatus(int status)
        {
            try
            {
                var cacheCustomerPackages = _cache.StringGet($"customer-packages-status:{status}").ToString();
                var data = JsonConvert.DeserializeObject<List<CustomerPackage>>(cacheCustomerPackages);
                if (cacheCustomerPackages != null && cacheCustomerPackages.Any())
                {
                    return cacheCustomerPackages.Select(x => _mapper.Map<CustomerPackageModel>(x)).ToList();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            var result = await _unitOfWork._customerPackageRepository.GetCustomerPackageByStatus(status);
            var returnedData = _mapper.Map<List<CustomerPackageModel>>(result).ToList();
            if (result.Any())
            {
                Task.WhenAll(
                   ProducerMessage.ProductUpdateRedisMessage<List<CustomerPackageModel>>("update-customer-packages", "create", returnedData, $"customer-packages-status:{status}")
               );
            }
            return returnedData;
        }

        public async Task<List<CustomerPackageModel>> GetListOrder(int? start = null, int? end = null, string sorted = "", string orders = "", string packageName = "", int? customerId = null, int? packageId = null, int? status = null, DateTime? dateFrom = null, DateTime? dateTo = null, string receiverName = "", string receiverPhone = "", string receiverAddress = "", double? maxPrice = null, double? minPrice = null, int? transactionId = null, int? quantityOfItems = null, double? maxTotalDeposit = null, double? minTotalDeposit = null)
        {
            try
            {
                var result = await _unitOfWork._customerPackageRepository.GetListOrder(null, null, sorted, orders, packageName, customerId, packageId, status, dateFrom, dateTo, receiverName, receiverPhone, receiverAddress, maxPrice, minPrice, transactionId, quantityOfItems, maxTotalDeposit, minTotalDeposit);

                result = result.ToList();
                return _mapper.Map<List<CustomerPackageModel>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CustomerPackageModel> GetPackagebyId(int packageid)
        {
            try
            {
                var cacheCustomerPackages = _cache.StringGet($"customer-packages-id:{packageid}").ToString();
                var data = JsonConvert.DeserializeObject<CustomerPackage>(cacheCustomerPackages);
                if (cacheCustomerPackages != null && cacheCustomerPackages.Any())
                {
                    return _mapper.Map<CustomerPackageModel>(cacheCustomerPackages);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            var result = await _unitOfWork._customerPackageRepository.GetCustomerPackageById(packageid);
            var returnedData = _mapper.Map<CustomerPackageModel>(result);
            if (result != null)
            {
                Task.WhenAll(
                   ProducerMessage.ProductUpdateRedisMessage<CustomerPackageModel>("update-customer-packages-byId" + packageid, "create", returnedData, $"customer-packages-id:{packageid}")
               );
            }
            return returnedData;
        }
        public async Task<List<CustomerPackageModel>> GetCustomerPackageRentProductByCustomerId(int customerId)
        {
            var result = (await _unitOfWork._customerPackageRepository.GetCustomerPackageByCustomerId(customerId)).Where(x=>x.Status==1 ||(x.Status==2 && x.IsReturnedDeposit==false)).ToList();
            result.ForEach(x=>x.Items?.ForEach(x=>x.Quantity= x.Quantity-x.ReturnedQuantity));
            return _mapper.Map<List<CustomerPackageModel>>(result);
        }

        public async Task<List<CustomerPackageModel>> GetNotReturnedMoneyCustomerPackage()
        {
            var result = (await _unitOfWork._customerPackageRepository.GetAllCustomerPackage()).Where(x => x.Status != 0 && x.Status != -1 && x.IsReturnedDeposit == false).ToList();
            result.ForEach(x => x.Items?.ForEach(x => x.Quantity = x.Quantity - x.ReturnedQuantity));
            return _mapper.Map<List<CustomerPackageModel>>(result);
        }
    }


}
