﻿
using Microsoft.AspNetCore.Http;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.CategoryService
{
    public interface ICategoryService
    {
        public Task<List<CategoryModel>> GetAllCategories();
        public Task<List<CategoryModel>> GetFeaturedCategories();
        public Task<CategoryModel> GetCategoryById(int id);
        
        public Task<CategoryModel> CreateCategory(CategoryModel category);
        public Task<CategoryModel> UpdateCategory(CategoryModel category);
        public Task<CategoryModel> ChangeStatus(int id, int status);
        public  Task<string> UploadCategoryImage(IFormFile image);
    }
}
