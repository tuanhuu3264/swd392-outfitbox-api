using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.Services.FavouriteProduct;
using SWD392.OutfitBox.DataLayer.Entities;
using System.Collections.Generic;
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
        [HttpPost("favourited-products/customers/{customerId}/products/{productId}")]
        public async Task<ActionResult<BaseResponse<FavouriteProductModel>>> CreateFavouriteProduct(int customerId, int productId)
        {
            BaseResponse<FavouriteProductModel> response;
            try
            {
                var data = await _favouriteProductService.CreateFavouriteProduct(productId, customerId);
                response = new BaseResponse<FavouriteProductModel>("Create favourite product successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<FavouriteProductModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return response;
        }
        [HttpDelete("favourited-products/customers/{customerId}/products/{productId}")]
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
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("favourited-products/customers/{customerId}")]
        public async Task<ActionResult<BaseResponse<List<ProductModel>>>> GetFavouriteProductByCustomerId([FromRoute] int customerId)
        {
            BaseResponse<List<ProductModel>> response;
            try
            {
                var data = await _favouriteProductService.GetByCustomerId(customerId);
                if (data == null)
                {
                    throw new Exception("List Null");
                }
                response = new BaseResponse<List<ProductModel>>("Favourited products", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<ProductModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
    }      
}
