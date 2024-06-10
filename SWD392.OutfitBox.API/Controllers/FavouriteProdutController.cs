using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.FavouriteProduct;
using SWD392.OutfitBox.BusinessLayer.Services.FavouriteProduct;
using System.Net;

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
        public async Task<ActionResult<BaseResponse<CreateFavouriteProductResponseDTO>>> CreateFavouriteProduct(int customerId, int productId)
        {
            BaseResponse<CreateFavouriteProductResponseDTO> response; 
            try
            {
                var data = await _favouriteProductService.CreateFavouriteProduct(productId, customerId);
                response = new BaseResponse<CreateFavouriteProductResponseDTO>("Create favourite product successfully.", HttpStatusCode.OK, data);
            }catch(Exception ex)
            {
                response = new BaseResponse<CreateFavouriteProductResponseDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return response;
        }
        [HttpDelete(FavouriteProductEndpoints.DeleteFavouriteProduct)]
        public async Task<ActionResult<BaseResponse<string>>> DeleteFavouriteProduct(int customerId, int productId)
        {
            BaseResponse<string> response;
            try
            {
                var data = await _favouriteProductService.CreateFavouriteProduct(productId, customerId);
                response = new BaseResponse<string>("Delete favourite product successfully.", HttpStatusCode.OK, "");
            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<string>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<string>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode,response);
        }
    }
}
