using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Repositories
{
    public class ProductReturnOrderRepository : BaseRepository<ProductReturnOrder>, IProductReturnOrderRepository
    {
        public ProductReturnOrderRepository(Context context) : base(context)
        {
        }

        public async Task<List<ProductReturnOrder>> CreateProductReturnOrders(ProductReturnOrder[] productReturnOrder)
        {
            await this.AddRangeAsync(productReturnOrder);
            await this.SaveChangesAsync();
            return await this.Get().OrderByDescending(x=>x.Id).Take(productReturnOrder.Length).ToListAsync();
        }

        public async Task<ProductReturnOrder> GetProductReturnOrderById(int Id)
        {
            return await this.Get().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<ProductReturnOrder>> GetProductsReturnOrder()
        {
            return await this.Get().ToListAsync();
        }

        public async Task<bool> RemoveProductReturnOrderById(int id)
        {
            var result = await this.GetById(id);
            await this.Delete(result);
            await this.SaveChangesAsync();
            return true;
        }

        public async Task<ProductReturnOrder> UpdatePoductReturnOrder(ProductReturnOrder productReturnOrder)
        {
           await this.Update(productReturnOrder);
            await this.SaveChangesAsync();
            return await this.Get().FirstAsync(x=>x.Id== productReturnOrder.Id);
        }
    }
}
