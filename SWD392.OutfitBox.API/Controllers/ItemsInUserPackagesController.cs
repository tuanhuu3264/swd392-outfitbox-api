using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.ItemInUserPackage;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.ItemInUserPackage;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Product;
using SWD392.OutfitBox.BusinessLayer.Services.ItemInUserPackageService;
using System.Net;

namespace SWD392.OutfitBox.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsInUserPackagesController : ControllerBase
    {
        readonly IItemsInUserPackageService _itemsInUserPackageService;
        public ItemsInUserPackagesController(IItemsInUserPackageService itemsInUserPackageService)
        {
            _itemsInUserPackageService = itemsInUserPackageService;
        }
        [HttpGet(ItemInUserPackageEndPoints.ItemInUserPackages)]
        public async Task<ActionResult> GetAll()
        {
            BaseResponse<List<ItemInUserPackageDto>> response;
            try
            {
                var result = await _itemsInUserPackageService.GetAll();
                if (result == null) { response = new BaseResponse<List<ItemInUserPackageDto>>("List Null",HttpStatusCode.InternalServerError, null); }
                response = new BaseResponse<List<ItemInUserPackageDto>>("Items in user package", HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<ItemInUserPackageDto>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode,response);
        }
        [HttpPost(ItemInUserPackageEndPoints.ItemInUserPackages)]
        public async Task<ActionResult> CreateAnItemInUserPackage([FromBody] CreatedItemInPackage createdItemInPackage)
        {
            BaseResponse<ItemInUserPackageDto> response;
            try
            {
                var result = await _itemsInUserPackageService.CreateItem(createdItemInPackage);
                if (result == null) { response = new BaseResponse<ItemInUserPackageDto>("Fail", HttpStatusCode.InternalServerError, null); }
                response = new BaseResponse<ItemInUserPackageDto>("Successful", HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<ItemInUserPackageDto>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPut(ItemInUserPackageEndPoints.ItemInUserPackages)]
        public async Task<ActionResult> UpdateAnItemInUserPackage([FromBody] UpdateItemInPackage updateItemInPackage)
        {
            BaseResponse<ItemInUserPackageDto> response;
            try
            {
                var result = await _itemsInUserPackageService.UpdateItem(updateItemInPackage);
                if (result == null) { response = new BaseResponse<ItemInUserPackageDto>("Fail", HttpStatusCode.InternalServerError, null); }
                response = new BaseResponse<ItemInUserPackageDto>("Successful", HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<ItemInUserPackageDto>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }


    }
}
