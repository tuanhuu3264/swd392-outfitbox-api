using SWD392.OutfitBox.BusinessLayer.Models.Responses.FavouriteProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.FavouriteProduct
{
    public interface IFavouriteProductService
    {
        public Task<CreateFavouriteProductResponseDTO> CreateFavouriteProduct(int productId, int customerId);
        public Task<DeleteFavouriteProductResponseDTO> DeleteFavouriteProduct(int productId, int customerId);

    }
}
