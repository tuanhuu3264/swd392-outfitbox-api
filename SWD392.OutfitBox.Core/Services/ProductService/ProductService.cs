using AutoMapper;
using SWD392.OutfitBox.Core.Constants;
using SWD392.OutfitBox.Core.Models.Requests.Product;
using SWD392.OutfitBox.Core.Models.Responses.Product;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Domain.Entities;
using SWD392.OutfitBox.Infrastructure.Repositories;
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
        public ProductService(IProductRepository repository, IMapper mapper, ICategoryRepository categoryRepository,
            IBrandRepository brandRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
        }

        public async Task<StatusCodeResponse<List<ProductGeneral>>> GetAll()
        {
            var result = new StatusCodeResponse<List<ProductGeneral>>();
            var products = await _repository.GetAll();
            var data = _mapper.Map<List<ProductGeneral>>(products);
            result.Data = data;
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }
        public async Task<StatusCodeResponse<ProductDetailDto>> CreateProduct(CreatedProductDto createdProduct)
        {
            var result = new StatusCodeResponse<ProductDetailDto>();
            try
            {
                var product = _mapper.Map<Product>(createdProduct);
                product.Brand = await _brandRepository.GetById(product.IdBrand);
                if (product.Brand == null) { throw new Exception("Can not find Brand"); }
                product.Category = await _categoryRepository.GetById(product.IdCategory);
                if (product.Category == null) { throw new Exception("Can not find Category"); }
                var productCreate = await _repository.CreateProduct(product);
                var data = _mapper.Map<ProductDetailDto>(productCreate);
                result.Data = data;
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
        public async Task<StatusCodeResponse<bool>> UpdateProduct(UpdateProductDto updateProduct)
        {
            var result = new StatusCodeResponse<bool>();
            try
            {
                var product = await _repository.GetById(updateProduct.ID);
                if (product == null) { throw new Exception("Can't not find this Id"); }
                product = _mapper.Map<Product>(updateProduct);
                var flag = await _repository.UpdateProduct(product);
                if(!flag) { throw new Exception("Can't Update this object"); }
                result.Data = flag;
                result.StatusCode = HttpStatusCode.OK;
                result.BonusData = product;
                return result;
            }
            catch(Exception ex) {
                result.Data = false;
                result.StatusCode = HttpStatusCode.InternalServerError;
                result.Message = ex.Message;
                return result;
            }
        }
        public async Task<StatusCodeResponse<ProductDetailDto>> GetById(int Id)
        {
            var result = new StatusCodeResponse<ProductDetailDto>();
            try
            {   
                var product = await _repository.GetById(Id);
                if (product.ID <=0 ) throw new Exception("Can't not find this Id");
                var data = _mapper.Map<ProductDetailDto>(product);
                result.Data = data;
                result.StatusCode = HttpStatusCode.OK;
                return result;
            }
            catch(Exception ex) {
                result.Data = null;
                result.StatusCode = HttpStatusCode.InternalServerError;
                result.Message = ex.Message;      
                return result; 
            }
           
        }
    }
}
