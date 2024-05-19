using SWD392.OutfitBox.Domain.Entities;

namespace SWD392.OutfitBox.Infrastructure.Repositories
{
    public interface IBrandRepository
    {
        Task<Brand> CreateBrand(Brand brand);
        Task<List<Brand>> GetAllBrands();
        Task<Brand> GetById(int id);
        Task<Brand> UpdateBrand(Brand brand);
    }
}