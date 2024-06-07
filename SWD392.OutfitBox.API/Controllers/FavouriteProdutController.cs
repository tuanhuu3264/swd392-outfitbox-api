using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.FavouriteProduct;
using SWD392.OutfitBox.BusinessLayer.Services.FavouriteProduct;

namespace SWD392.OutfitBox.API.Controllers
{
   
    [ApiController]
    public class FavouriteProdutController : ControllerBase
    {
        public IFavouriteProductService _favouriteProductService;
        public FavouriteProdutController(IFavouriteProductService favouriteProductService)
        {
            _favouriteProductService = favouriteProductService;
        }
        [HttpPost(FavouriteProductEndpoints.CreateFavouriteProduct)]
        public async Task<CreateFavouriteProductResponseDTO> CreateFavouriteProduct(int customerId, int productId)
        {
            var result = await _favouriteProductService.CreateFavouriteProduct(productId, customerId);
            return result;
        }
        [HttpDelete(FavouriteProductEndpoints.DeleteFavouriteProduct)]
        public async Task<DeleteFavouriteProductResponseDTO> DeleteFavouriteProduct(int customerId, int productId)
        {
            var result = await _favouriteProductService.DeleteFavouriteProduct(customerId, productId);
            return result;
        }
    }
}
