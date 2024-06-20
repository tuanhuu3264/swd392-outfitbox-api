    using AutoMapper;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using SWD392.OutfitBox.DataLayer.UnitOfWork;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using Microsoft.AspNetCore.Http;
using SWD392.OutfitBox.DataLayer.Firebase;
using Microsoft.Extensions.Configuration;


namespace SWD392.OutfitBox.BusinessLayer.Services.ProductService
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _repository;
        readonly IMapper _mapper;
        readonly ICategoryRepository _categoryRepository;
        readonly IBrandRepository _brandRepository;
        readonly IUnitOfWork _unitOfWork;
        readonly IConfiguration _configuration; 
        public ProductService(IProductRepository repository, IMapper mapper, ICategoryRepository categoryRepository,
            IBrandRepository brandRepository, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<List<ProductModel>> GetList(int? pageIndex = null, int? pageSize = null, string sorted = "", string orders = "", string name = "", List<int>? idBrand = null, List<int>? idCategory = null, int? status = null, double? maxMoney = null, double? minMoney = null)
        {
            var products = await _unitOfWork._productRepository.GetStartEnd(pageIndex, pageSize, sorted, orders, name, idBrand, idCategory, status, maxMoney, minMoney);
            var data = _mapper.Map<List<ProductModel>>(products);
            return data;
        }
        public async Task<ProductModel> CreateProduct(ProductModel createdProduct)
        {
            var product = _mapper.Map<Product>(createdProduct);
            product.Status = 0;
            product.IsUsed = "False";
            product.AvailableQuantity = product.Quantity;
            if (createdProduct.IdBrand.HasValue == false) throw new Exception("There is no id brand in model.");
            product.Brand = await _unitOfWork._brandRepository.GetById(createdProduct.IdBrand.Value);
            if (createdProduct.IdCategory.HasValue == false) throw new Exception("There is no id in model.");
            if (product.Brand == null) { throw new ArgumentNullException("Can not find Brand"); }
            product.Category = await _categoryRepository.GetById(createdProduct.IdCategory.Value);
            if (product.Category == null) { throw new ArgumentNullException("Can not find Category"); }
            var productCreate = await _repository.CreateProduct(product);
            var data = _mapper.Map<ProductModel>(productCreate);
            return data;
        }
        public async Task<ProductModel> UpdateProduct(ProductModel updateProduct)
        {
            if (updateProduct.ID.HasValue == false) throw new Exception("There is no id in model.");
            //await _unitOfWork._imageRepository.DeleteImageByProductId(updateProduct.ID.Value);
            var product = await _repository.GetDetail(updateProduct.ID.Value);
            if (product == null) { throw new ArgumentNullException("Can't not find this Id"); }
            product = _mapper.Map(updateProduct, product);
            var flag = await _repository.UpdateProduct(product);
            var result = _mapper.Map<ProductModel>(flag);
            return result;
        }
        public async Task<ProductModel> GetById(int Id)
        {
            var product = await _repository.GetById(Id);
            if (product.ID <= 0) throw new ArgumentNullException("Can't not find this Id");
            var data = _mapper.Map<ProductModel>(product);
            return data;
        }

        public async Task<List<string>> UploadFiles(List<IFormFile> files)
        {   
            var urls = await FirebaseStorageHelper.UploadFilesToFirebase(files, $"{nameof(Product).ToLower()}", _configuration["Firebase:ApiKey"], _configuration["Firebase:DomainName"], _configuration["Firebase:Email"], _configuration["Firebase:Password"], _configuration["Firebase:StorageBucket"]);
            return urls;
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            var url = await FirebaseStorageHelper.UploadFileToFirebase(file, $"{nameof(Product).ToLower()}", _configuration["Firebase:ApiKey"], _configuration["Firebase:DomainName"], _configuration["Firebase:Email"], _configuration["Firebase:Password"], _configuration["Firebase:StorageBucket"]);
            return url;
        }
    }
}
