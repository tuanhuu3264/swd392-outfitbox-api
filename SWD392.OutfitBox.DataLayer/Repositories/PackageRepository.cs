using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SWD392.OutfitBox.Core.RepoInterfaces;
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
             this.Update(package);
            await this.SaveChangesAsync();
            return await GetPackageById(package.Id);
        }
    }
}
