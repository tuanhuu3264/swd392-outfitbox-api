using SWD392.OutfitBox.DataLayer.Entities;

namespace SWD392.OutfitBox.DataLayer.Interfaces
{
    public interface IBrandRepository
    {
        Task<Brand> CreateBrand(Brand brand);
        Task<List<Brand>> GetAllBrands();
        Task<Brand> GetById(int id);
        Task<Brand> UpdateBrand(Brand brand);
        public Task<bool> DeleteBrand(Brand brand);
    }
}