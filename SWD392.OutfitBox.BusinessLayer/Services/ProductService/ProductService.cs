using AutoMapper;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Product;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Product;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using SWD392.OutfitBox.DataLayer.UnitOfWork;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.ProductService
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _repository;
        readonly IMapper _mapper;
        readonly ICategoryRepository _categoryRepository;
        readonly IBrandRepository _brandRepository;
        readonly IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository repository, IMapper mapper, ICategoryRepository categoryRepository,
            IBrandRepository brandRepository,IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ProductGeneral>> GetList(int? pageIndex = null, int? pageSize = null, string sorted = "", string orders = "", string name = "", List<int>? idBrand = null, List<int>? idCategory = null,int? status =null, double? maxMoney = null, double? minMoney = null)
        {
            var products = await _unitOfWork._productRepository.GetStartEnd(pageIndex,pageSize,sorted,orders,name,idBrand,idCategory,status,maxMoney,minMoney);
            var data = _mapper.Map<List<ProductGeneral>>(products);
            return data;
        }
        public async Task<ProductDetailDto> CreateProduct(CreatedProductDto createdProduct)
        {
                var product = _mapper.Map<ProductModel>(createdProduct);
                product.Status = 0;
                product.AvailableQuantity = product.Quantity;
                product.Brand = await _unitOfWork._brandRepository.GetById(createdProduct.IdBrand);
                if (product.Brand == null) { throw new ArgumentNullException("Can not find Brand"); }
                product.Category = await _categoryRepository.GetById(product.IdCategory);
                if (product.Category == null) { throw new ArgumentNullException("Can not find Category"); }
                var productCreate = await _repository.CreateProduct(product);
                var data = _mapper.Map<ProductDetailDto>(productCreate);
                return data;
        }
        public async Task<ProductDetailDto> UpdateProduct(ProductModel updateProduct)
        {
                await _unitOfWork._imageRepository.DeleteImageByProductId(updateProduct.ID);
                var product = await _repository.GetDetail(updateProduct.ID);
                if (product == null) { throw new ArgumentNullException("Can't not find this Id"); }
                product = _mapper.Map(updateProduct, product);
                var flag = await _repository.UpdateProduct(product);
                var result = _mapper.Map<ProductDetailDto>(flag);
                return result;
        }
        public async Task<ProductDetailDto> GetById(int Id)
        {
                var product = await _repository.GetById(Id);
                if (product.ID <=0 ) throw new ArgumentNullException("Can't not find this Id");
                var data = _mapper.Map<ProductDetailDto>(product);
                return data;
        }
    }
}
