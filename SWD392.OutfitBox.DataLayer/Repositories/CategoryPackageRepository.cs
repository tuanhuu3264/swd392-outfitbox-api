﻿using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Repositories
{
    public class CategoryPackageRepository : BaseRepository<CategoryPackage>, ICategoryPackageRepository
    {
        public CategoryPackageRepository(Context context) : base(context)
        {
        }

        public async Task<CategoryPackage> CreateCategoryPackage(CategoryPackage categoryPackage)
        {
            var result = await this.AddAsync(categoryPackage);
            return await this.Get().OrderBy(x=>x.Id).LastAsync();
        }

        public async Task<bool> DeleateCategoryPackageById(int id)
        {
            var result = await GetCategoryPackageById(id);
            if (result == null) throw new Exception("There is not found the categoryPackage that has id: "+id);
            await this.Delete(result);
            await this.SaveChangesAsync();
            return true;
        }

        public async Task<List<CategoryPackage>> GetAllCategoryPackagesByPackageId(int packageId)
        {
            return await this.Get().Where(x => x.PackageId == packageId).Include(x => x.Package).Include(x => x.Category).ToListAsync();
        }

        public async Task<CategoryPackage> GetCategoryPackageByCategoryIdAndPackageId(int categoryId, int packageId)
        {
            return await this.Get().Where(x => x.PackageId == packageId && x.CategoryId== categoryId).FirstAsync();
        }

        public async Task<CategoryPackage> GetCategoryPackageById(int id)
        {
            var result = await this.Get().Where(x => x.Id== id).FirstOrDefaultAsync();
            if(result == null) return new CategoryPackage();
            return result;
        }

        public async Task<CategoryPackage> UpdateCategoryPackage(CategoryPackage categoryPackage)
        {
            await this.Update(categoryPackage);
            await this.SaveChangesAsync();
            return await GetCategoryPackageById(categoryPackage.Id);
        }
       
    }
}
