using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.CategoryPackage;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Package;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.CategoryPackage;
using SWD392.OutfitBox.BusinessLayer.Services.CategoryPackageService;
using SWD392.OutfitBox.DataLayer.Entities;
using System.Net;

namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class CategoryPackageController : ControllerBase
    {
        public ICategoryPackageService _categoryPackageService;
        public CategoryPackageController(ICategoryPackageService categoryPackageService)
        {
            _categoryPackageService = categoryPackageService;
        }
        [HttpGet(CategoryPackageEndpoints.GetAllCategoryPackagesByPackageId)]
        public async Task<ActionResult<BaseResponse<List<CategoryPackageDTO>>>> GetAllCategoryPackageByPackageId([FromRoute] int packageId)
        {
            BaseResponse<List<CategoryPackageDTO>> response;
            try
            {
                var data = await _categoryPackageService.GetAllCategoryPackagesByPackageId(packageId);
                response = new BaseResponse<List<CategoryPackageDTO>>("Get successfully category packages by package id:" + packageId, HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<CategoryPackageDTO>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost(CategoryPackageEndpoints.CreateCategoryPackage)]
        public async Task<ActionResult<BaseResponse<CreateCategoryPackageResponseDTO>>> CreateCategoryPackage([FromBody] CreateCategoryPackageRequestDTO request)
        {
            BaseResponse<CreateCategoryPackageResponseDTO> response;
            try
            {
                var data = await _categoryPackageService.CreatePackage(request);
                response = new BaseResponse<CreateCategoryPackageResponseDTO>("Create successfully category package.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CreateCategoryPackageResponseDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPut(CategoryPackageEndpoints.UpdateCategoryPackage)]
        public async Task<ActionResult<BaseResponse<UpdateCategoryPackageResponseDTO>>> UpdateCategoryPackage([FromBody] UpdateCategoryPackageRequestDTO request)
        {
            BaseResponse<UpdateCategoryPackageResponseDTO> response;
            try
            {
                var data = await _categoryPackageService.UpdatePackage(request);
                response = new BaseResponse<UpdateCategoryPackageResponseDTO>("Update successfully category package.", HttpStatusCode.OK, data);
            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<UpdateCategoryPackageResponseDTO>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<UpdateCategoryPackageResponseDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpDelete(CategoryPackageEndpoints.DeleteCategoryPackage)]
        public async Task<ActionResult<BaseResponse<string>>> DeleteCategoryPackageById(int id)
        {
            BaseResponse<string> response;
            try
            {
                var data = await _categoryPackageService.DeletePackageById(id);
                response = new BaseResponse<string>("Delete successfully category package.", HttpStatusCode.OK, "data");
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

    }
}
