
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.FavouriteProduct
{
    public interface IFavouriteProductService
    {
        public Task<FavouriteProductModel> CreateFavouriteProduct(int productId, int customerId);
        public Task<bool> DeleteFavouriteProduct(int productId, int customerId);
        Task<List<ProductModel>> GetByCustomerId(int customerId);
    }
}
