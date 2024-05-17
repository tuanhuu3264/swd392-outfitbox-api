using SWD392.OutfitBox.Core.Constants;
using SWD392.OutfitBox.Core.Models.Requests.Product;
using SWD392.OutfitBox.Domain.Entities;

namespace SWD392.OutfitBox.Core.Services.ProductService
{
    public interface IProductService
    {
        Task<StatusCodeResponse<List<Product>>> GetAll();
        Task<StatusCodeResponse<Product>> CreateProduct(CreatedProductDto createdProduct);
    }
}
