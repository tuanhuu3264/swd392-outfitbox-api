using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.API.DTOs.Category;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.Services.CategoryService;


using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public ICategoryService _categoryService;
        public IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet(CategoryEndpoints.GetAllCategories)]
        public async Task<ActionResult<BaseResponse<List<CategoryModel>>>> GetAllCategories()
        {
            BaseResponse<List<CategoryModel>> response;
            try
            {
                var data = await _categoryService.GetAllCategories();
                response = new BaseResponse<List<CategoryModel>>("Get categories successfully.", HttpStatusCode.OK,data);
            } catch (Exception ex)
            {
                response = new BaseResponse<List<CategoryModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("categories/featured-categories")]
        public async Task<ActionResult<BaseResponse<List<CategoryModel>>>> GetFeaturedCategories()
        {
            BaseResponse<List<CategoryModel>> response;
            try
            {
                var data = await _categoryService.GetFeaturedCategories();
                response = new BaseResponse<List<CategoryModel>>("Get categories successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<CategoryModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet(CategoryEndpoints.GetCategoryById)]
        public async Task<ActionResult<BaseResponse<CategoryModel>>> GetCategoryById([FromRoute] int id)
        {
            BaseResponse<CategoryModel> response;
            try
            {
                var data = await _categoryService.GetCategoryById(id);
                response = new BaseResponse<CategoryModel> ("Get categories successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CategoryModel> (ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost(CategoryEndpoints.CreateCategory)]
        public async Task<ActionResult<BaseResponse<CategoryModel>>> CreateCategory([FromBody] CreateCategoryRequestDTO createCategoryRequestDTO)
        {
            BaseResponse<CategoryModel> response;
            try
            {   
                var mapping = _mapper.Map<CategoryModel>(createCategoryRequestDTO);
                var data = await _categoryService.CreateCategory(mapping);
                response = new BaseResponse<CategoryModel>("Create category successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CategoryModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPatch("categories/{id}")]
        public async Task<ActionResult<BaseResponse<CategoryModel>>> UpdateCategory([FromRoute] int id, [FromBody] UpdateCategoryRequestDTO updateCategoryRequestDTO)
        {
            BaseResponse<CategoryModel> response;
            try
            {
                var mapping = _mapper.Map<CategoryModel>(updateCategoryRequestDTO);
                mapping.ID = id;
                var data = await _categoryService.UpdateCategory(mapping);
                response = new BaseResponse<CategoryModel>("Update category successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CategoryModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPut("categories/{id}/status/{status}")]
        public async Task<ActionResult<BaseResponse<CategoryModel>>> ActiveOrDeactiveCategory([FromBody]int id, [FromRoute] int status)
        {
            BaseResponse<CategoryModel> response;
            try
            {
                var data = await _categoryService.ChangeStatus(id, status);
                response = new BaseResponse<CategoryModel>("Update category successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CategoryModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost("categories/uploaded-file")]
        public async Task<IActionResult> UpdateFile(IFormFile file)
        {
            BaseResponse<string> response;
            try
            {

                var result = await _categoryService.UploadCategoryImage(file);
                response = new BaseResponse<string>("Product:", HttpStatusCode.OK, result);
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
