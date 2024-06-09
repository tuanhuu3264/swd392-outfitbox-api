
using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(Context context) : base(context)
        {
        }

        public async Task<Category> CreateCategory(Category category)
        {
            var result = await this.AddAsync(category);
            await this.SaveChangesAsync();
            return result;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await this.Get().ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            var result = await this.Get().FirstOrDefaultAsync(x=>x.ID==id);
            if (result == null) return new Category();
            return result;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            this.Update(category);
            await this.SaveChangesAsync();
            var result = await this.Get().FirstAsync(x=>x.ID==category.ID); 
            return result;
        }
    }
}
