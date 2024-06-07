using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.RepoInterfaces
{
    public interface ICategoryPackageRepository
    {
        public Task<List<CategoryPackage>> GetAllCategoryPackagesByPackageId(int packageId); 
        public Task<CategoryPackage> GetCategoryPackageByCategoryIdAndPackageId(int categoryId, int packageId);
        public Task<CategoryPackage> GetCategoryPackageById(int id);    
        public Task<CategoryPackage> CreateCategoryPackage(CategoryPackage categoryPackage);
        public Task<CategoryPackage> UpdateCategoryPackage(CategoryPackage categoryPackage);
        public Task<bool> DeleateCategoryPackageById(int id);
    }
}
