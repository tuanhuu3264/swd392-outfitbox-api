
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.BusinessModels.PaymentModels;
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
        public Task<List<ReturnOrderModel>> GetReturnOrders(int? pageNumber = null, int? pageSize = null, int? partnerid = null, int? customerId = null);
        public Task<ReturnOrderModel> CreateReturnOrder(ReturnOrderModel requestDTO);
        public Task<string> DeleteReturnOrder(int id);
        public Task<ReturnOrderModel> GetReturnOrderById(int id);
        public Task<ReturnOrderModel> ChangeStatus(int id, int status);
        public Task<List<ProductInReturnOrderViewModel>> GetByReturnOrderId(int returnOrderId);
    }
}
