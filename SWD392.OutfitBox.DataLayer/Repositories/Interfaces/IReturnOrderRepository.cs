using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Interfaces
{
    public interface IReturnOrderRepository
    {
        public Task<List<ReturnOrder>> GetReturnOrders(int? pageNumber = null, int? pageSize =null, int? partnerid = null ,int? customerId = null);

        public Task<ReturnOrder> GetReturnOrderById(int id);
        
        public Task<ReturnOrder> CreateReturnOrder(ReturnOrder returnOrder);
        public Task<ReturnOrder> UpdateReturnOrder(ReturnOrder returnOrder);
        public Task DeleteReturnOrder(ReturnOrder returnOrder);
  
    }
}
