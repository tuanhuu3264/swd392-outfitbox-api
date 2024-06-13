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
            await this.Delete(deletedFavouriteProduct);
            await this.SaveChangesAsync();
            return true;
        }
    }
}
