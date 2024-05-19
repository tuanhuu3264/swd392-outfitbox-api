using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.Core.Models.Requests.CategoryPackage;
using SWD392.OutfitBox.Core.Models.Requests.Package;
using SWD392.OutfitBox.Core.Models.Responses.CategoryPackage;
using SWD392.OutfitBox.Core.Services.CategoryPackageService;

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
        public async Task<List<CategoryPackageDTO>> GetAllCategoryPackageByPackageId([FromRoute] int packageId)
        {
            var result = await _categoryPackageService.GetAllCategoryPackagesByPackageId(packageId);
            return result;
        }
        [HttpPost(CategoryPackageEndpoints.CreateCategoryPackage)]
        public async Task<CreateCategoryPackageResponseDTO> CreateCategoryPackage([FromBody] CreateCategoryPackageRequestDTO request)
        {
            var result = await _categoryPackageService.CreatePackage(request);
            return result;
        }
        [HttpPut(CategoryPackageEndpoints.UpdateCategoryPackage)]
        public async Task<UpdateCategoryPackageResponseDTO> UpdateCategoryPackage([FromBody] UpdateCategoryPackageRequestDTO request)
        {
            var result = await _categoryPackageService.UpdatePackage(request);
            return result;
        }
        [HttpDelete(CategoryPackageEndpoints.DeleteCategoryPackage)]
        public async Task<DeleteCategoryPackageResponseDTO> DeleteCategoryPackageById(int id)
        {
            var result = await _categoryPackageService.DeletePackageById(id);
            return result;
        }
        
    }
}
