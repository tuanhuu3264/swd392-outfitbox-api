using AutoMapper;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.Entities;
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
            var mappingReturnOrder = _mapper.Map<ReturnOrder>(requestDTO);
            var result = await _unitOfWork._returnOrderRepository.CreateReturnOrder(mappingReturnOrder);
            return _mapper.Map<ReturnOrderModel>(result);
        }

        public async Task<string> DeleteReturnOrder(int id)
        {
            var deletedReturnOrder = await _unitOfWork._returnOrderRepository.GetReturnOrderById(id);
            if (deletedReturnOrder == null) throw new ArgumentNullException("There is not found the return order that has id: "+id);
            await _unitOfWork._returnOrderRepository.DeleteReturnOrder(deletedReturnOrder);
            return "Delete return order successfully";
        }

        public async Task<List<ReturnOrderModel>> GetReturnOrders(int? pageNumber = null, int? pageSize = null, int? partnerid = null, int? customerId = null)
        {
            return (await _unitOfWork._returnOrderRepository.GetReturnOrders(pageNumber, pageSize, partnerid, customerId)).Select(x=> _mapper.Map<ReturnOrderModel>(x)).ToList();   
        }

        public async Task<ReturnOrderModel> GetReturnOrderById(int id)
        {
            return _mapper.Map<ReturnOrderModel>(await _unitOfWork._returnOrderRepository.GetReturnOrderById(id));
        }

        public async Task<ReturnOrderModel> ChangeStatus(int id, int status)
        {
            var returnOrder = await _unitOfWork._returnOrderRepository.GetReturnOrderById(id);
            if (returnOrder == null) throw new ArgumentNullException("There is no return order has id :" + id);
            if (returnOrder.Status == status) { throw new Exception("This return order has this Status"); }
            returnOrder.Status=status;
            if (status > 0)
            {
              foreach(var item in returnOrder.ProductReturnOrders)
                {
                   item.Status = status;// khuc nay k biet
                   var product = await _unitOfWork._productRepository.GetById(item.ProductId);
                   if(product == null) { throw new ArgumentNullException("Not Found this Product"); }
                   product.AvailableQuantity = product.AvailableQuantity + item.Quantity;
                   await _unitOfWork._productRepository.UpdateProduct(product);
                }
              
            }
            await _unitOfWork._returnOrderRepository.UpdateReturnOrder(returnOrder);
            return _mapper.Map<ReturnOrderModel>(returnOrder);
        }
    }
}
