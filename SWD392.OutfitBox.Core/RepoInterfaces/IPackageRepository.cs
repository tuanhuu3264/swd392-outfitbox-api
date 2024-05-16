using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.RepoInterfaces
{
    public interface IPackageRepository
    {
        public Task<List<Package>> GetAllPackage();
        public Task<Package> GetPackageById(int id);
        public Task<Package> CreatePackage(Package package);
        public Task<Package> UpdatePackage(Package package);
    }
}
