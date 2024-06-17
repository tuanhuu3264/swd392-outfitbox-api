using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.API.DTOs.CategoryPackage;
using SWD392.OutfitBox.API.DTOs.CreatePackage;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.Services.CategoryPackageService;
using SWD392.OutfitBox.DataLayer.Entities;
using System.Net;

namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class CategoryPackageController : ControllerBase
    {
        public ICategoryPackageService _categoryPackageService;
        public IMapper _mapper;
        public CategoryPackageController(ICategoryPackageService categoryPackageService, IMapper mapper)
        {
            _categoryPackageService = categoryPackageService;
            _mapper = mapper;   
        }
        [HttpGet(CategoryPackageEndpoints.GetAllCategoryPackagesByPackageId)]
        public async Task<ActionResult<BaseResponse<List<CategoryPackageModel>>>> GetAllCategoryPackageByPackageId([FromRoute] int packageId)
        {
            BaseResponse<List<CategoryPackageModel>> response;
            try
            {
                var data = await _categoryPackageService.GetAllCategoryPackagesByPackageId(packageId);
                response = new BaseResponse<List<CategoryPackageModel>>("Get successfully category packages by package id:" + packageId, HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<CategoryPackageModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost(CategoryPackageEndpoints.CreateCategoryPackage)]
        public async Task<ActionResult<BaseResponse<CategoryPackageModel>>> CreateCategoryPackage([FromBody] CreateCategoryPackageRequestDTO request)
        {
            BaseResponse<CategoryPackageModel> response;
            try
            {   
                var mapping = _mapper.Map<CategoryPackageModel>(request);   
                var data = await _categoryPackageService.CreatePackage(mapping);
                response = new BaseResponse<CategoryPackageModel>("Create successfully category package.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CategoryPackageModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPatch("category-packages/{id}")]
        public async Task<ActionResult<BaseResponse<CategoryPackageModel>>> UpdateCategoryPackage([FromRoute] int id, [FromBody] UpdateCategoryPackageRequestDTO request)
        {
            BaseResponse<CategoryPackageModel> response;
            try
            {
                var mapping = _mapper.Map<CategoryPackageModel>(request);
                mapping.Id = id;
                var data = await _categoryPackageService.UpdatePackage(mapping);
                response = new BaseResponse<CategoryPackageModel>("Update successfully category package.", HttpStatusCode.OK, data);
            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<CategoryPackageModel>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CategoryPackageModel>(ex.Message, HttpStatusCode.InternalServerError, null);
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
