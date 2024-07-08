using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.API.DTOs.ItemInUserPackage;
using SWD392.OutfitBox.API.RequestModels.CustomerPackage;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;

using SWD392.OutfitBox.BusinessLayer.Services.ItemInUserPackageService;
using System.Net;

namespace SWD392.OutfitBox.API.Controllers
{

    [ApiController]
    public class ItemsInUserPackagesController : ControllerBase
    {
        readonly IItemsInUserPackageService _itemsInUserPackageService;
        public IMapper _mapper { get; set; }
        public ItemsInUserPackagesController(IMapper mapper,IItemsInUserPackageService itemsInUserPackageService)
        {
            _itemsInUserPackageService = itemsInUserPackageService;
            _mapper = mapper;
        }
        [HttpGet(ItemInUserPackageEndPoints.ItemsInUserPackages)]
        public async Task<ActionResult> GetAll()
        {
            BaseResponse<List<ItemInUserPackageModel>> response;
            try
            {
                var result = await _itemsInUserPackageService.GetAll();
                if (result == null) { response = new BaseResponse<List<ItemInUserPackageModel>>("List Null",HttpStatusCode.InternalServerError, null); }
                response = new BaseResponse<List<ItemInUserPackageModel>>("Items in customer package", HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<ItemInUserPackageModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode,response);
        }
        [HttpPost(ItemInUserPackageEndPoints.ItemsInUserPackageId)]
        public async Task<ActionResult> CreateAnItemInUserPackage([FromBody] CreateItemInUserPackage createdItemInPackage, [FromRoute] int id)
        {
            BaseResponse<ItemInUserPackageModel> response;
            try
            {   
                var mapping = _mapper.Map<ItemInUserPackageModel>(createdItemInPackage);
                var result = await _itemsInUserPackageService.CreateItem(id,mapping);
                if (result == null) { response = new BaseResponse<ItemInUserPackageModel>("Fail", HttpStatusCode.InternalServerError, null); }
                response = new BaseResponse<ItemInUserPackageModel>("Successful", HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<ItemInUserPackageModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPatch("products-in-customer-package/{id}")]
        public async Task<ActionResult> UpdateAnItemInUserPackage([FromRoute] int id, [FromBody] UpdateItemInPackage updateItemInPackage)
        {
            BaseResponse<ItemInUserPackageModel> response;
            try
            {
                var mapping = _mapper.Map<ItemInUserPackageModel>(updateItemInPackage);
                mapping.Id = id;
                var result = await _itemsInUserPackageService.UpdateItem(mapping);
                if (result == null) { response = new BaseResponse<ItemInUserPackageModel>("Fail", HttpStatusCode.InternalServerError, null); }
                response = new BaseResponse<ItemInUserPackageModel>("Successful", HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<ItemInUserPackageModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpDelete(ItemInUserPackageEndPoints.ItemInUserPackages)]
        public async Task<ActionResult> DeleteAnItemInUserPackage([FromRoute] int id)
        {
            BaseResponse<bool> response;
            try
            {
                var result = await _itemsInUserPackageService.DeleteItem(id);
                if (result == false) { response = new BaseResponse<bool>("Fail", HttpStatusCode.InternalServerError,false ); }
                response = new BaseResponse<bool>("Successful", HttpStatusCode.OK,true );
            }
            catch(ArgumentException ex)
            {
                response = new BaseResponse<bool>(ex.Message, HttpStatusCode.NotFound, false);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<bool>(ex.Message, HttpStatusCode.InternalServerError, false);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet(ItemInUserPackageEndPoints.ItemsInUserPackageId)]
        public async Task<ActionResult> GetItemsbyCustomerPackageId([FromRoute] int id)
        {
            BaseResponse<List<ItemInUserPackageModel>> response;
            try
            {
                var result = await _itemsInUserPackageService.GetByUserPackageId(id);
                if (result == null) { response = new BaseResponse<List<ItemInUserPackageModel>>("List Null", HttpStatusCode.InternalServerError, null); }
                response = new BaseResponse<List<ItemInUserPackageModel>>("Items in customer package", HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<ItemInUserPackageModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
