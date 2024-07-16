using AutoMapper;
using FirebaseAdmin.Messaging;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using StackExchange.Redis;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.BusinessModels.PaymentModels;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.FirebaseCloudMessaging;
using SWD392.OutfitBox.DataLayer.Streaming.ProducerMessage;
using SWD392.OutfitBox.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.ReturnOrderService
{
    public class ReturnOrderService : IReturnOrderService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public IMapper _mapper { get; set; }
        public IDatabase _cache { get; set; }
        public ReturnOrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            ConnectionMultiplexer con = ConnectionMultiplexer.Connect("outfit4rent.online:6379");
            _cache = con.GetDatabase();
        }

        public async Task<ReturnOrderModel> CreateReturnOrder(ReturnOrderModel requestDTO)
        {
            if (requestDTO.ProductReturnOrders == null || !requestDTO.ProductReturnOrders.Any())
                throw new Exception("There are no products in the return order");

            var mappingReturnOrder = _mapper.Map<ReturnOrder>(requestDTO);

            var customer = await _unitOfWork._customerRepository.GetCustomerById(requestDTO.CustomerId.Value);
            if (customer == null)
                throw new Exception("No customer found with ID: " + requestDTO.CustomerId.Value);

            var customerPackage = await _unitOfWork._customerPackageRepository.GetCustomerPackageById(requestDTO.CustomerPackageId.Value);
            if (customerPackage == null)
                throw new Exception("No order found with ID: " + requestDTO.CustomerPackageId.Value);

            if (customerPackage.CustomerId != customer.Id)
                throw new Exception("The user doesn't have permission to create this return order");
            if (customerPackage.Status == 0 || customerPackage.Status == -1 || (customerPackage.IsReturnedDeposit == true))
                throw new Exception("The return order can be created as it is invalid status to create");
            var partner = await _unitOfWork._partnerRepository.GetPartnerById(requestDTO.PartnerId.Value);
            if (partner == null)
                throw new Exception("No partner found with ID: " + requestDTO.PartnerId.Value);

            var productIds = customerPackage.Items.Select(x => x.ProductId).ToHashSet();
            foreach (var item in requestDTO.ProductReturnOrders)
            {
                if (!productIds.Contains((int)item.ProductId))
                    throw new Exception("Product with ID: " + item.ProductId + " not found in the original order to return");
            }
            Dictionary<int, int> updatedQuantity = new Dictionary<int, int>();
            Dictionary<int, int> checkSuitableQuantity = customerPackage.Items
                .ToDictionary(x => x.ProductId, x => x.Quantity - x.ReturnedQuantity);

            foreach (var item in requestDTO.ProductReturnOrders)
            {
                if (checkSuitableQuantity.TryGetValue((int)item.ProductId, out var availableQuantity))
                {
                    if (availableQuantity == 0)
                        throw new Exception("There are too many products with ID: " + item.ProductId + " to return");
                    if (item.Quantity > availableQuantity)
                        throw new Exception("There are too many products with ID: " + item.ProductId + " to return");
                    updatedQuantity.Add((int)item.ProductId, (int)item.Quantity);
                }
                else
                {
                    throw new Exception("Product with ID: " + item.ProductId + " not found in the original order");
                }
            }
            using (_unitOfWork.BenginTransaction())
            {
                await _unitOfWork.CommitTransaction();
                try
                {

                    Dictionary<int, double> moneyPerProduct = new Dictionary<int, double>();
                    var productsInCustomerPackage = await _unitOfWork._itemsInUserPackageRepository.GetByUserPackageId(mappingReturnOrder.CustomerPackageId);
                    foreach (var item in productsInCustomerPackage)
                    {
                        if (updatedQuantity.TryGetValue(item.ProductId, out int quantity))
                        {   
                            moneyPerProduct.Add(item.ProductId, item.Deposit/item.Quantity);
                            item.ReturnedQuantity += quantity;
                            await _unitOfWork._itemsInUserPackageRepository.UpdateItem(item);
                        }
                    }

                    if(mappingReturnOrder.ProductReturnOrders!=null)
                    foreach(var item in mappingReturnOrder.ProductReturnOrders)
                        {
                            if (moneyPerProduct.TryGetValue(item.ProductId, out double price))
                            {

                                if (item.DamagedLevel == 1) item.ThornMoney = item.Quantity * price * 0.2;
                                if (item.DamagedLevel == 2) item.ThornMoney = item.Quantity * price * 0.5;
                                if (item.DamagedLevel == 3) item.ThornMoney = item.Quantity * price * 1;
                            }
                        }
                    mappingReturnOrder.Status = 0;
                    mappingReturnOrder.CreatedAt = DateTime.Now;
                    mappingReturnOrder.QuantityOfItems = requestDTO.ProductReturnOrders.Sum(x => x.Quantity.Value);

                    var result = await _unitOfWork._returnOrderRepository.CreateReturnOrder(mappingReturnOrder);
                    Task.WhenAll(
                         ProducerMessage.ProductUpdateRedisMessage<List<CustomerPackageModel>>("delete-customer-packages-by-customerId", "delete", null, $"customer-packages-customer:{requestDTO.CustomerId}"),
                         ProducerMessage.ProductUpdateRedisMessage<List<CustomerPackageModel>>("delete-customer-packages-by-statusId", "delete", null, $"customer-packages-status:{1}"),
                         ProducerMessage.ProductUpdateRedisMessage<CustomerPackageModel>("delete-customer-packages-byId" + requestDTO.Id, "delete", null, $"customer-packages-id:{requestDTO.Id}")

                         );
                    FirebaseCloudMessagingHelper.SendNotificationToTopic("new-orders", "You have a new return order.", "The return order is created. Please to check! Return Order Id: " + result.Id);
                    return _mapper.Map<ReturnOrderModel>(result);
                }
                catch (Exception ex)
                {
                    await _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<string> DeleteReturnOrder(int id)
        {
            var deletedReturnOrder = await _unitOfWork._returnOrderRepository.GetReturnOrderById(id);
            if (deletedReturnOrder == null) throw new ArgumentNullException("There is not found the return order that has id: " + id);
            await _unitOfWork._returnOrderRepository.DeleteReturnOrder(deletedReturnOrder);
            return "Delete return order successfully";
        }

        public async Task<List<ReturnOrderModel>> GetReturnOrders(int? pageNumber = null, int? pageSize = null, int? partnerid = null, int? customerId = null)
        {
            return (await _unitOfWork._returnOrderRepository.GetReturnOrders(pageNumber, pageSize, partnerid, customerId)).Select(x => _mapper.Map<ReturnOrderModel>(x)).ToList();
        }

        public async Task<ReturnOrderModel> GetReturnOrderById(int id)
        {
            return _mapper.Map<ReturnOrderModel>(await _unitOfWork._returnOrderRepository.GetReturnOrderById(id));
        }

        public async Task<ReturnOrderModel> ChangeStatus(int id, int status, List<ProductReturnOrderModel> models)
        {
            Message message = new Message();
            using (var transaction = _unitOfWork.BenginTransaction())
            {
                try
                {
                    var returnOrder = await _unitOfWork._returnOrderRepository.GetReturnOrderById(id);
                    if (returnOrder == null)
                        throw new ArgumentNullException($"There is no return order with id: {id}");

                    if (returnOrder.Status == status)
                        throw new Exception("This return order already has this status.");

                   
                    Dictionary<int, int> updatedQuantity = new Dictionary<int, int>();
                    if (returnOrder.ProductReturnOrders != null)
                    {
                        foreach (var item in returnOrder.ProductReturnOrders)
                        {
                            item.Status = status;
                            await _unitOfWork._productReturnOrderRepository.UpdatePoductReturnOrder(item);
                            updatedQuantity[item.ProductId] = item.Quantity;
                        }
                    }
                    if (returnOrder.Status == 0 && status == 1)
                    {

                        var productsInReturnOrder = await _unitOfWork._productReturnOrderRepository.GetProductReturnOrderByReturnOrderId(id);
                        foreach (var item in productsInReturnOrder)
                        {
                            var product = await _unitOfWork._productRepository.GetById(item.ProductId);
                            if (item.DamagedLevel != 3) product.Quantity += item.Quantity;
                            await _unitOfWork._productRepository.UpdateProduct(product);
                        }
                        foreach(var model in models)
                        {
                            var productInReturnOrder = await _unitOfWork._productReturnOrderRepository.GetProductReturnOrderById(id);
                            productInReturnOrder.ThornMoney = (double)model.ThornMoney;
                            productInReturnOrder.DamagedLevel= (int)model.DamagedLevel;
                            await _unitOfWork._productReturnOrderRepository.UpdatePoductReturnOrder(productInReturnOrder);
                        }
                        message = new Message()
                        {
                            Notification = new Notification()
                            {
                                Title = "Completed Orders",
                                Body = $"Your return order {returnOrder.Id} is completed"
                            }
                        };
                    } else if(returnOrder.Status == 0 && status == -1)
                    {
                        var productInOrder = await _unitOfWork._itemsInUserPackageRepository.GetByUserPackageId(returnOrder.CustomerPackageId);
                        foreach(var  item in productInOrder)
                        {
                            if(updatedQuantity.TryGetValue(item.ProductId, out int quantity ))
                            {
                                item.ReturnedQuantity-= quantity;
                                await _unitOfWork._itemsInUserPackageRepository.UpdateItem(item);
                            }
                        }
                        message = new Message()
                        {
                            Notification = new Notification()
                            {
                                Title = "Canceled Orders",
                                Body = $"Your return order {returnOrder.Id} is Canceled"
                            }
                        };
                    }

                    returnOrder.Status = status;
                    await _unitOfWork._returnOrderRepository.UpdateReturnOrder(returnOrder);
                    await _unitOfWork.CommitTransaction();
                    if(status ==1 || status ==2 )
                    try
                    {
                            var token = _cache.StringGet("partner:device-tokens:" + returnOrder.PartnerId);
                            if (token.HasValue)
                            {
                                message.Token = token;
                                FirebaseCloudMessagingHelper.SendNotificationByMessage(message);
                            }
                    }
                    catch (Exception ex)
                    {

                    }
                    return _mapper.Map<ReturnOrderModel>(returnOrder);
                }
                catch (Exception ex)
                {
                    await _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
        }
        public async Task<List<ProductInReturnOrderViewModel>> GetByReturnOrderId(int returnOrderId)
        {
            var listProductsInOrderViewModel = await _unitOfWork._productReturnOrderRepository.GetProductReturnOrderByReturnOrderId(returnOrderId);
            return _mapper.Map<List<ProductInReturnOrderViewModel>>(listProductsInOrderViewModel);

        }
    }
}
