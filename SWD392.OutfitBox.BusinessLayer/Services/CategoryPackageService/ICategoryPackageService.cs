
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.CategoryPackageService
{
    public interface ICategoryPackageService
    {
        public Task<List<CategoryPackageModel>> GetAllCategoryPackagesByPackageId(int packageId);
        public Task<CategoryPackageModel> CreatePackage(CategoryPackageModel request);
        public Task<CategoryPackageModel> UpdatePackage(CategoryPackageModel request);
        public Task<bool> DeletePackageById(int id); 
    }
}
