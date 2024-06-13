using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SWD392.OutfitBox.DataLayer.Repositories
{
    public class ReturnOrderRepository : BaseRepository<ReturnOrder>, IReturnOrderRepository
    {
        public ReturnOrderRepository(Context context) : base(context)
        {
        }

        public async Task<ReturnOrder> CreateReturnOrder(ReturnOrder returnOrder)
        {
            await this.AddAsync(returnOrder);
            await this.SaveChangesAsync();
            return await this.Get().OrderBy(x => x.Id).FirstAsync();
        }

        public async Task DeleteReturnOrder(ReturnOrder returnOrder)
        {
             await this.Delete(returnOrder);
             await this.SaveChangesAsync();
        }

        public async Task<ReturnOrder> GetReturnOrderById(int id)
        {
            return await this.Get().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ReturnOrder>> GetReturnOrders(int? pageNumber = null, int? pageSize = null, int? partnerid = null, int? customerId = null)
        {
            var query = this.Get();
            if(partnerid.HasValue) query=query.Where(x=>x.PartnerId==partnerid.Value);
            if(customerId.HasValue) query=query.Where(x=>x.CustomerId==customerId.Value);
            if(pageSize.HasValue && pageNumber.HasValue) query = query.Skip((pageNumber.Value - 1) * pageSize.Value);
            return await query.ToListAsync();
            
        }

        public async Task<ReturnOrder> UpdateReturnOrder(ReturnOrder returnOrder)
        {
           await this.Update(returnOrder);
            await this.SaveChangesAsync();
            return await this.Get().FirstAsync(x=>x.Id==returnOrder.Id);
        }
    }
}
