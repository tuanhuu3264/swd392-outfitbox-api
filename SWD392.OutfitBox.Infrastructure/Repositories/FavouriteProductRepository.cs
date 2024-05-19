using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Domain.Entities;
using SWD392.OutfitBox.Infrastructure.Databases.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Infrastructure.Repositories
{
    public class FavouriteProductRepository : BaseRepository<FavouriteProduct>, IFavouriteProductRepository
    {
        public FavouriteProductRepository(Context context) : base(context)
        {
        }

        public async Task<FavouriteProduct> CreateFavouriteProductByCustomerIdAndProductId(int customerId, int productId)
        {
            var favouriteProduct = new FavouriteProduct() { CustomerId= customerId,ProductId=productId};
            await this.AddAsync(favouriteProduct);
            await this.SaveChangesAsync();
            return await this.Get().Where(x => x.ProductId == productId && x.CustomerId == customerId).FirstAsync();
        }

        public async Task<bool> DeleteFavouriteProductByCustomerIdAndProductId(int customerId, int productId)
        {
            var deletedFavouriteProduct = await this.Get().Where(x=>x.CustomerId==customerId && x.ProductId==productId).FirstAsync();
            this.Delete(deletedFavouriteProduct);
            await this.SaveChangesAsync();
            return true;
        }
    }
}
