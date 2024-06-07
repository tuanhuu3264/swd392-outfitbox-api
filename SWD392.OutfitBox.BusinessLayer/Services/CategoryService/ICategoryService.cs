
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Category;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.CategoryService
{
    public interface ICategoryService
    {
        public Task<List<CategoryDTO>> GetAllCategories();
        public Task<CategoryDTO> GetCategoryById(int id);
        
        public Task<CreateCategoryResponseDTO> CreateCategory(CreateCategoryRequestDTO category);
        public Task<UpdateCategoryResponseDTO> UpdateCategory(UpdateCategoryRequestDTO category);
        public Task<CategoryDTO> ActiveOrDeactiveCategory(int id);
    }
}
