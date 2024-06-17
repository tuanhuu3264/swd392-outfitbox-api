using AutoMapper;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {   
        public ICategoryRepository _categoryRepository { get; set; }
        public IMapper _mapper; 
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CategoryModel> ActiveOrDeactiveCategory(int id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null) throw new Exception("Not found the category that has id: " + id);
            category.Status = 0; 
            var updatedCategory = await _categoryRepository.UpdateCategory(category);
            return _mapper.Map<CategoryModel>(updatedCategory);
        }

        public async Task<CategoryModel> CreateCategory(CategoryModel category)
        {
            category.Status = 1;
            var mappingCategory = _mapper.Map<Category>(category);
            var createdCategory = await _categoryRepository.CreateCategory(mappingCategory);
            return _mapper.Map<CategoryModel>(createdCategory);
        }

        public async Task<List<CategoryModel>> GetAllCategories()
        {
            return (await _categoryRepository.GetAllCategories()).Select(x=>_mapper.Map<CategoryModel>(x)).ToList();
        }

        public async Task<CategoryModel> GetCategoryById(int id)
        {
            return _mapper.Map<CategoryModel>(await _categoryRepository.GetById(id)); 
        }

        public async Task<CategoryModel> UpdateCategory(CategoryModel category)
        {
            var checkingCategory = await _categoryRepository.GetById(category.ID.Value);

            if (checkingCategory == null) throw new Exception("Not found the category that has id: " + category.ID);
            
            _mapper.Map(category,checkingCategory);
            
            var updatedCategory = await _categoryRepository.UpdateCategory(checkingCategory);
            return _mapper.Map<CategoryModel>(updatedCategory);
        }
    }
}
