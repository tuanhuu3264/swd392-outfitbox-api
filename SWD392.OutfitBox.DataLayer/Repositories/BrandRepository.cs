﻿
using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Interfaces;
using SWD392.OutfitBox.DataLayer;
using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Repositories
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        public BrandRepository(Context context) : base(context)
        {
        }

        public async Task<Brand> CreateBrand(Brand brand)
        {
            var result = await this.AddAsync(brand);
            await this.SaveChangesAsync();
            return result;
        }

        public async Task<List<Brand>> GetAllBrands()
        {
            return await this.Get().ToListAsync();
        }

        public async Task<Brand> GetById(int id)
        {
            var result = await this.Get().Include(x=>x.Products).FirstOrDefaultAsync(x => x.ID == id);
            if (result == null) return null;
            return result;
        }

        public async Task<Brand> UpdateBrand(Brand brand)
        {
            await this.Update(brand);
            await this.SaveChangesAsync();
            var result = await this.Get().FirstAsync(x => x.ID == brand.ID);
            return result;
        }
        public async Task<bool> DeleteBrand(Brand brand)
        {
            await this.Delete(brand);
            return true;
        }
    }
}
