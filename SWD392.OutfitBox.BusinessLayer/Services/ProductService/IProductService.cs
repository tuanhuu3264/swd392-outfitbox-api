
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Product;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Product;
using SWD392.OutfitBox.DataLayer.Entities;
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
        Task<List<ProductGeneral>> GetList(int? pageIndex = null, int? pageSize = null, string sorted = "", string orders = "", string name = "", List<int>? idBrand = null, List<int>? idCategory = null,int? status=null, double? maxMoney = null, double? minMoney = null);
        Task<ProductDetailDto> CreateProduct(CreatedProductDto createdProduct);
        Task<ProductDetailDto> GetById(int Id);
        Task<ProductDetailDto> UpdateProduct(ProductModel updateProduct);
        
    }
}
