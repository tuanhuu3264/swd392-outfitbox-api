using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Controllers.Endpoints;
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
        public async Task<ActionResult<CategoryDTO>> GetAllCategories()
        {
            return Ok(await _categoryService.GetAllCategories());
        }
    }
}
