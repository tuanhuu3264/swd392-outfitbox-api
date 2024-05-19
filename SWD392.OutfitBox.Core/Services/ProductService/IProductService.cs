using SWD392.OutfitBox.Core.Constants;
using SWD392.OutfitBox.Core.Models.Requests.Product;
using SWD392.OutfitBox.Core.Models.Responses.Product;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWD392.OutfitBox.Core.Services.ProductService
{
    public interface IProductService
    {
        Task<StatusCodeResponse<List<ProductDetailDto>>> GetAll();
        Task<StatusCodeResponse<ProductDetailDto>> CreateProduct(CreatedProductDto createdProduct);
    }
}
