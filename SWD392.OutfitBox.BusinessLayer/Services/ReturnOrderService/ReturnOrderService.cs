using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.BusinessModels.PaymentModels;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Migrations;
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
        public ReturnOrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

            var partner = await _unitOfWork._partnerRepository.GetPartnerById(requestDTO.PartnerId.Value);
            if (partner == null)
                throw new Exception("No partner found with ID: " + requestDTO.PartnerId.Value);

            var productIds = customerPackage.Items.Select(x => x.ProductId).ToHashSet();
            foreach (var item in requestDTO.ProductReturnOrders)
            {
                if (!productIds.Contains((int)item.ProductId))
                    throw new Exception("Product with ID: " + item.ProductId + " not found in the original order to return");
            }

            Dictionary<int, int> checkSuitableQuantity = customerPackage.Items
                .ToDictionary(x => x.ProductId, x => x.Quantity - x.ReturnedQuantity);

            foreach (var item in requestDTO.ProductReturnOrders)
            {
                if (checkSuitableQuantity.TryGetValue((int)item.ProductId, out var availableQuantity))
                {
                    if (item.Quantity > availableQuantity)
                        throw new Exception("There are too many products with ID: " + item.ProductId + " to return");
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
                    Dictionary<int, int> updatedQuantity = new Dictionary<int, int>();
                    var productsInCustomerPackage = await _unitOfWork._itemsInUserPackageRepository.GetByUserPackageId(mappingReturnOrder.CustomerPackageId);
                    foreach (var item in productsInCustomerPackage)
                    {
                        if (updatedQuantity.TryGetValue(item.ProductId, out int quantity))
                        {
                            item.ReturnedQuantity += quantity;
                            await _unitOfWork._itemsInUserPackageRepository.UpdateItem(item);
                        }
                    }

                    mappingReturnOrder.Status = 0;
                    mappingReturnOrder.CreatedAt = DateTime.Now;
                    mappingReturnOrder.QuantityOfItems = requestDTO.ProductReturnOrders.Sum(x => x.Quantity.Value);

                    var result = await _unitOfWork._returnOrderRepository.CreateReturnOrder(mappingReturnOrder);
                    return _mapper.Map<ReturnOrderModel>(result);
                }catch(Exception ex)
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

        public async Task<ReturnOrderModel> ChangeStatus(int id, int status)
        {
            using (var transaction = _unitOfWork.BenginTransaction())
            {
                try
                {
                    var returnOrder = await _unitOfWork._returnOrderRepository.GetReturnOrderById(id);
                    if (returnOrder == null)
                        throw new ArgumentNullException($"There is no return order with id: {id}");

                    if (returnOrder.Status == status)
                        throw new Exception("This return order already has this status.");

                    returnOrder.Status = status;
                    Dictionary<int, int> updatedQuantity = new Dictionary<int, int>();

                    if (returnOrder.Status == 0 && status == 1)
                    {

                        var productsInReturnOrder = await _unitOfWork._productReturnOrderRepository.GetProductReturnOrderByReturnOrderId(id);
                        foreach (var item in productsInReturnOrder)
                        {
                            var product = item.Product;
                            product.Quantity += item.Quantity;
                            await _unitOfWork._productRepository.UpdateProduct(product);
                        }
                    }
                    if (returnOrder.ProductReturnOrders != null)
                    {
                        foreach (var item in returnOrder.ProductReturnOrders)
                        {
                            item.Status = status;
                            await _unitOfWork._productReturnOrderRepository.UpdatePoductReturnOrder(item);
                            updatedQuantity[item.ProductId] = item.Quantity;
                        }
                    }
                    await _unitOfWork._returnOrderRepository.UpdateReturnOrder(returnOrder);
                    await _unitOfWork.CommitTransaction();

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
