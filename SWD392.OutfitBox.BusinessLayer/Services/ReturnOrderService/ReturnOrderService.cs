using AutoMapper;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.ReturnOrder;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.ReturnOrder;
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

        public async Task<CreateReturnOrderResponseDTO> CreateReturnOrder(CreateReturnOrderRequestDTO requestDTO)
        {
            var mappingReturnOrder = _mapper.Map<ReturnOrder>(requestDTO);
            var result = await _unitOfWork._returnOrderRepository.CreateReturnOrder(mappingReturnOrder);
            return _mapper.Map<CreateReturnOrderResponseDTO>(result);
        }

        public async Task<string> DeleteReturnOrder(int id)
        {
            var deletedReturnOrder = await _unitOfWork._returnOrderRepository.GetReturnOrderById(id);
            if (deletedReturnOrder == null) throw new ArgumentNullException("There is not found the return order that has id: "+id);
            await _unitOfWork._returnOrderRepository.DeleteReturnOrder(deletedReturnOrder);
            return "Delete return order successfully";
        }

        public async Task<List<ReturnOrderDTO>> GetReturnOrders(int? pageNumber = null, int? pageSize = null, int? partnerid = null, int? customerId = null)
        {
            return _unitOfWork._returnOrderRepository.GetReturnOrders(pageNumber, pageSize, partnerid, customerId).Result.Select(x=> _mapper.Map<ReturnOrderDTO>(x)).ToList();   
        }

        public async Task<ReturnOrderDTO> GetReturnOrderById(int id)
        {
            return _mapper.Map<ReturnOrderDTO>(await _unitOfWork._returnOrderRepository.GetReturnOrderById(id));
        }

        public async Task<ReturnOrderDTO> ChangeStatus(int id, int status)
        {
            var returnOrder = await _unitOfWork._returnOrderRepository.GetReturnOrderById(id);
            if (returnOrder == null) throw new ArgumentNullException("There is no return order has id :" + id);
            returnOrder.Status=status;
            await _unitOfWork._returnOrderRepository.UpdateReturnOrder(returnOrder);
            return _mapper.Map<ReturnOrderDTO>(returnOrder);
        }
    }
}
