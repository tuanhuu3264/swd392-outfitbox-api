
using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Domain;
using SWD392.OutfitBox.Domain.Entities;
using SWD392.OutfitBox.Infrastructure.Databases.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Infrastructure.Repositories
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
            var result = await this.Get().FirstOrDefaultAsync(x => x.ID == id);
            if (result == null) return new Brand();
            return result;
        }

        public async Task<Brand> UpdateBrand(Brand brand)
        {
            this.Update(brand);
            await this.SaveChangesAsync();
            var result = await this.Get().FirstAsync(x => x.ID == brand.ID);
            return result;
        }
    }
}
