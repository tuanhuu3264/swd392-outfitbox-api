using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.Core.Models.Requests.Category;
using SWD392.OutfitBox.Core.Models.Responses.Category;
using SWD392.OutfitBox.Core.Services.CategoryService;

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
        public async Task<ActionResult<List<CategoryDTO>>> GetAllCategories()
        {
            return Ok(await _categoryService.GetAllCategories());
        }

        [HttpGet(CategoryEndpoints.GetCategoryById)]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById([FromRoute] int id)
        {
            return Ok(await _categoryService.GetCategoryById(id));
        }
        [HttpPost(CategoryEndpoints.CreateCategory)]
        public async Task<ActionResult<CreateCategoryResponseDTO>> CreateCategory([FromBody] CreateCategoryRequestDTO createCategoryRequestDTO)
        {
            var result = await _categoryService.CreateCategory(createCategoryRequestDTO);
            
            return Ok(result);
        }
        [HttpPut(CategoryEndpoints.UpdateCategory)]
        public async Task<ActionResult<UpdateCategoryResponseDTO>> UpdateCategory([FromBody] UpdateCategoryRequestDTO updateCategoryRequestDTO)
        {
            var result = await _categoryService.UpdateCategory(updateCategoryRequestDTO); 
            return Ok(result);
        }
        [HttpPut(CategoryEndpoints.ActiveOrDeactiveCategory)]
        public async Task<ActionResult<CategoryDTO>> ActiveOrDeactiveCategory([FromBody]int id)
        {
            var result = await _categoryService.ActiveOrDeactiveCategory(id);
            return Ok(result);
        }
    }
}
