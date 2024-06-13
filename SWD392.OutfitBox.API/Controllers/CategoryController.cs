using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Category;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Category;
using SWD392.OutfitBox.BusinessLayer.Services.CategoryService;


using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet(CategoryEndpoints.GetAllCategories)]
        public async Task<ActionResult<BaseResponse<List<CategoryDTO>>>> GetAllCategories()
        {
            BaseResponse<List<CategoryDTO>> response;
            try
            {
                var data = await _categoryService.GetAllCategories();
                response = new BaseResponse<List<CategoryDTO>>("Get categories successfully.", HttpStatusCode.OK,data);
            } catch (Exception ex)
            {
                response = new BaseResponse<List<CategoryDTO>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet(CategoryEndpoints.GetCategoryById)]
        public async Task<ActionResult<BaseResponse<CategoryDTO>>> GetCategoryById([FromRoute] int id)
        {
            BaseResponse<CategoryDTO> response;
            try
            {
                var data = await _categoryService.GetCategoryById(id);
                response = new BaseResponse<CategoryDTO> ("Get categories successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CategoryDTO> (ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost(CategoryEndpoints.CreateCategory)]
        public async Task<ActionResult<BaseResponse<CreateCategoryResponseDTO>>> CreateCategory([FromBody] CreateCategoryRequestDTO createCategoryRequestDTO)
        {
            BaseResponse<CreateCategoryResponseDTO> response;
            try
            {
                var data = await _categoryService.CreateCategory(createCategoryRequestDTO);
                response = new BaseResponse<CreateCategoryResponseDTO>("Create category successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CreateCategoryResponseDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPut(CategoryEndpoints.UpdateCategory)]
        public async Task<ActionResult<BaseResponse<UpdateCategoryResponseDTO>>> UpdateCategory([FromBody] UpdateCategoryRequestDTO updateCategoryRequestDTO)
        {
            BaseResponse<UpdateCategoryResponseDTO> response;
            try
            {
                var data = await _categoryService.UpdateCategory(updateCategoryRequestDTO);
                response = new BaseResponse<UpdateCategoryResponseDTO>("Update category successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<UpdateCategoryResponseDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPut("categories/{id}/status/{status}")]
        public async Task<ActionResult<BaseResponse<CategoryDTO>>> ActiveOrDeactiveCategory([FromBody]int id)
        {
            BaseResponse<CategoryDTO> response;
            try
            {
                var data = await _categoryService.ActiveOrDeactiveCategory(id);
                response = new BaseResponse<CategoryDTO>("Update category successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CategoryDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
