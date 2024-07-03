

using SWD392.OutfitBox.BusinessLayer.BusinessModels;

namespace SWD392.OutfitBox.BusinessLayer.Services.PackageService
{
    public interface IPackageService
    {
        public Task<List<PackageModel>> GetFeaturedPackages();
        public Task<List<PackageModel>> GetAllEnabledPackages();
        public Task<List<PackageModel>> GetAllPackages();
        public Task<PackageModel> CreatePackage(PackageModel package);
        public Task<PackageModel> UpdatePackage(PackageModel package);
        public Task<PackageModel> ChangeStatus(int id, int status);
        public Task<PackageModel> GetPackageById(int v);
    }
}
