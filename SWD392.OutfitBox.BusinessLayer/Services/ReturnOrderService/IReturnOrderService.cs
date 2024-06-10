using SWD392.OutfitBox.BusinessLayer.Models.Requests.ReturnOrder;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.ReturnOrder;
using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.ReturnOrderService
{
    public interface IReturnOrderService
    {
        public Task<List<ReturnOrderDTO>> GetReturnOrders(int? pageNumber = null, int? pageSize = null, int? partnerid = null, int? customerId = null);
        public Task<CreateReturnOrderResponseDTO> CreateReturnOrder(CreateReturnOrderRequestDTO requestDTO);
        public Task<string> DeleteReturnOrder(int id);
        public Task<ReturnOrderDTO> GetReturnOrderById(int id);
        public Task<ReturnOrderDTO> ChangeStatus(int id, int status);
    }
}
