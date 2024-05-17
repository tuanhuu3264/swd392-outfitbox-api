using AutoMapper;
using SWD392.OutfitBox.Core.Constants;
using SWD392.OutfitBox.Core.Models.Requests.Product;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Domain.Entities;
using SWD392.OutfitBox.Infrastructure.Repositories;
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
        readonly IMapper _mapper;
        readonly ICategoryRepository _categoryRepository;
        readonly IBrandRepository _brandRepository;
        readonly ITypeRepository _typeRepository;
        public ProductService(IProductRepository repository,IMapper mapper,ICategoryRepository categoryRepository,
            IBrandRepository brandRepository,ITypeRepository typeRepository)
        {
            _repository = repository;
            _mapper = mapper;  
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _typeRepository = typeRepository;
        }

        public async Task<StatusCodeResponse<List<Product>>> GetAll()
        {
            var result = new StatusCodeResponse<List<Product>>();
            var products = await _repository.GetAll();
            result.Data = products;
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }
        public async Task<StatusCodeResponse<Product>> CreateProduct(CreatedProductDto createdProduct)
        {
            var result = new StatusCodeResponse<Product>();
            try
            { 
                var product = _mapper.Map<Product>(createdProduct);
                product.Brand = await _brandRepository.GetById(product.IdBrand);
                if (product.Brand == null) { throw new Exception("Can not find Brand"); }
                product.Category = await _categoryRepository.GetById(product.IdCategory);
                if (product.Category == null) { throw new Exception("Can not find Category"); }
                product.Type = await _typeRepository.GetById(product.IdType);
                if (product.Type == null) { throw new Exception("Can not find Type"); }
                var productCreate = await _repository.CreateProduct(product);
             
                result.Data = productCreate;
                result.StatusCode = HttpStatusCode.OK;
                result.Message = "Successful";
                return result;
            }
            catch (Exception ex)
            { 
                result.Data = null;
                result.StatusCode = HttpStatusCode.InternalServerError;
                result.Message = ex.Message;
                return result;
            }
        }
    }
}
