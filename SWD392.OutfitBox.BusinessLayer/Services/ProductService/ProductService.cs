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
using Abp.Extensions;
using System.Management;


namespace SWD392.OutfitBox.BusinessLayer.Services.ProductService
{
    public class ProductService : IProductService
    {
       
        readonly IMapper _mapper;
    
        readonly IUnitOfWork _unitOfWork;
        readonly IConfiguration _configuration; 
        public ProductService(IMapper mapper,IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<List<ProductModel>> GetList(int? pageIndex = null, int? pageSize = null, string sorted = "", string orders = "", string name = "", List<int>? idBrand = null, List<int>? idCategory = null, int? status = null, double? maxMoney = null, double? minMoney = null)
        {
            var products = await _unitOfWork._productRepository.GetList(null, null, sorted, orders, name, idBrand, idCategory, status, maxMoney, minMoney);
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
            product.Category = await _unitOfWork._categoryRepository.GetById(createdProduct.IdCategory.Value);

            if (product.Category == null) { throw new ArgumentNullException("Can not find Category"); }
            var productCreate = await _unitOfWork._productRepository.CreateProduct(product);
            List <Image> images = new List<Image>();
            if(createdProduct.Images != null)
            {
                foreach(var item in createdProduct.Images)
                {
                    var newImage = await _unitOfWork._imageRepository.CreateImage(new Image()
                    {
                        Link = item.Link,
                        IdProduct=productCreate.ID
                    });
                    images.Add(newImage);
                }
            }
             productCreate.Images= images;
            var data = _mapper.Map<ProductModel>(productCreate);
            return data;
        }
        public async Task<ProductModel> UpdateProduct(ProductModel updateProduct)
        {
            if (!updateProduct.ID.HasValue)
            {
                throw new ArgumentException("There is no ID in the model.");
            }

            var product = await _unitOfWork._productRepository.GetDetail(updateProduct.ID.Value);
            if (product == null)
            {
                throw new ArgumentNullException($"Cannot find product with ID {updateProduct.ID.Value}.");
            }

            if (updateProduct.Images != null)
            {
                var existingImageLinks = product.Images?.Select(x => x.Link).ToHashSet();
                var newImagesToAdd = new List<Image>();

                var imagesToDelete = product.Images?.Where(img => !updateProduct.Images.Any(uimg => uimg.Link == img.Link)).ToList();
                
                if(imagesToDelete != null) 
                foreach (var img in imagesToDelete)
                {
                    await _unitOfWork._imageRepository.DeleteImageByProductId(img.ID);
                }

                foreach (var image in updateProduct.Images)
                {
                    if (existingImageLinks!=null && !existingImageLinks.Contains(image.Link))
                    {
                        await _unitOfWork._imageRepository.CreateImage(new Image { Link = image.Link, IdProduct = product.ID });
                    }
                   
                }
            }
            _mapper.Map(updateProduct, product);
            var updatedProduct = await _unitOfWork._productRepository.UpdateProduct(product);

            return _mapper.Map<ProductModel>(updatedProduct);
        }
        public async Task<ProductModel> GetById(int Id)
        {
            var product = await _unitOfWork._productRepository.GetById(Id);
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
