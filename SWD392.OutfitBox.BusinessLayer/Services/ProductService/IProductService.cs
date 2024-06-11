
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Product;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.ProductService
{
    public interface IProductService
    {
        Task<List<ProductGeneral>> GetAll();
        Task<ProductDetailDto> CreateProduct(CreatedProductDto createdProduct);
        Task<ProductDetailDto> GetById(int Id);
        Task<ProductDetailDto> UpdateProduct(UpdateProductDto updateProduct);
    }
}
