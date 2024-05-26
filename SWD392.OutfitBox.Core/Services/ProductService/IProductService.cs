using SWD392.OutfitBox.Core.Constants;
using SWD392.OutfitBox.Core.Models.Requests.Product;
using SWD392.OutfitBox.Core.Models.Responses.Product;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.ProductService
{
    public interface IProductService
    {
        Task<StatusCodeResponse<List<ProductGeneral>>> GetAll();
        Task<StatusCodeResponse<ProductDetailDto>> CreateProduct(CreatedProductDto createdProduct);
        Task<StatusCodeResponse<ProductDetailDto>> GetById(int Id);
        Task<StatusCodeResponse<bool>> UpdateProduct(UpdateProductDto updateProduct);
    }
}
