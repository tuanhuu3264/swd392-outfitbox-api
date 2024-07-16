using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;

namespace SWD392.OutfitBox.DataLayer.Repositories
{
    public class PackageRepository : BaseRepository<Package>, IPackageRepository
    {
        public PackageRepository(Context context) : base(context)
        {
        }

        public async Task<Package> CreatePackage(Package package)
        {
            var result= await this.AddAsync(package);
            await this.SaveChangesAsync();
            return result;
        }

        public async Task<List<Package>> GetAllPackage()
        {
            return await this.Get().Include(x=>x.CategoryPackages).ThenInclude(x=>x.Category).ToListAsync();
        }

        public async Task<Package> GetPackageById(int id)
        {
            var result = await this.Get().Include(x => x.CategoryPackages).ThenInclude(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (result == null) return new Package();
            return result;
        }

        public async Task<Package> UpdatePackage(Package package)
        {
            await this.Update(package);

            return await GetPackageById(package.Id);
        }
        public async Task<List<AdminObjectData>> GetDashboardPackages()
        {
            var list = await this.Get().Include(x => x.CustomerPackages).Select(x => new AdminObjectData
            {
                Id = x.Id,
                Name = x.Name,
                Value = x.CustomerPackages.Count(),
                Url = x.ImageUrl
            }).ToListAsync();
            return list;
        }

        public async Task<List<AdminObjectData>> GetDashboardPricePackages()
        {
            var list = await this.Get().Include(x => x.CustomerPackages).Select(x => new AdminObjectData
            {
                Id = x.Id,
                Name = x.Name,
                Value = x.CustomerPackages.Sum(x=>x.Price),
                Url = x.ImageUrl
            }).ToListAsync();
            return list;
        }
    }
}
