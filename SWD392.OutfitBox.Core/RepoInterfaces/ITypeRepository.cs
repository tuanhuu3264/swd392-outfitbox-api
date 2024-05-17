using SWD392.OutfitBox.Domain.Entities;

namespace SWD392.OutfitBox.Infrastructure.Repositories
{
    public interface ITypeRepository
    {
        Task<Domain.Entities.ProductType> CreateType(Domain.Entities.ProductType type);
        Task<List<ProductType>> GetAllTypes();
        Task<ProductType> GetById(int id);
        Task<ProductType> UpdateType(ProductType type);
    }
}