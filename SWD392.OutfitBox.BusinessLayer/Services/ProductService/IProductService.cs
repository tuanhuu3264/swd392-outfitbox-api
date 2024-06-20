
using Microsoft.AspNetCore.Http;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
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
        Task<List<ProductModel>> GetList(int? pageIndex = null, int? pageSize = null, string sorted = "", string orders = "", string name = "", List<int>? idBrand = null, List<int>? idCategory = null,int? status=null, double? maxMoney = null, double? minMoney = null);
        Task<ProductModel> CreateProduct(ProductModel createdProduct);
        Task<ProductModel> GetById(int Id);
        Task<ProductModel> UpdateProduct(ProductModel updateProduct);

        Task<List<string>> UploadFiles(List<IFormFile> files);
        Task<string> UploadFile(IFormFile file);

    }
}
