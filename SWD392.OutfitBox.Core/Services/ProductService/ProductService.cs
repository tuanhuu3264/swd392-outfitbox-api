using SWD392.OutfitBox.Core.Constants;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.ProductService
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<StatusCodeResponse<List<Product>>> GetAll()
        {
            var result = new StatusCodeResponse<List<Product>>();
            var products = await _repository.GetAll();
            result.Data = products;
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }
    }
}
