using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.API.DTOs.Product;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.Services.ProductService;
using System.Net;

namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductService _productService;
        readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet("products")]
        public async Task<IActionResult> GetAllForAdmin(
                                                [FromQuery(Name ="page_index")]
                                                int? pageIndex = null,
                                                [FromQuery(Name ="page_size")]
                                                int? pageSize = null,
                                                [FromQuery(Name ="_sort")]
                                                string sorted = "",
                                                [FromQuery(Name ="_order")]
                                                string orders = "",
                                                [FromQuery(Name ="name_like")]
                                                string name = "",
                                                [FromQuery(Name ="brand.id")]
                                                List<int>? idBrand = null,
                                                [FromQuery(Name = "category.id")]
                                                List<int>? idCategory = null,
                                                [FromQuery(Name ="_status")]
                                                int? status = null,
                                                [FromQuery(Name ="_deposit.max")]
                                                double? maxMoney = null,
                                                [FromQuery(Name ="_deposit.min")]
                                                double? minMoney = null,
            [FromQuery(Name ="is_featured")]
            bool? isFeatured = null)
        {
            BaseResponse<List<ProductModel>> response;
            try
            {
                var data = await _productService.GetList(pageIndex, pageSize, sorted, orders, name, idBrand, idCategory, status, maxMoney, minMoney,isFeatured);
                response = new BaseResponse<List<ProductModel>>("Get Product successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<ProductModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("customers/products")]
        public async Task<IActionResult> GetAllForCustomer(
                                                [FromQuery(Name ="page_index")]
                                                int? pageIndex = null,
                                                [FromQuery(Name ="page_size")]
                                                int? pageSize = null,
                                                [FromQuery(Name ="_sort")]
                                                string sorted = "",
                                                [FromQuery(Name ="_order")]
                                                string orders = "",
                                                [FromQuery(Name ="name_like")]
                                                string name = "",
                                                [FromQuery(Name ="brand.id")]
                                                List<int>? idBrand = null,
                                                [FromQuery(Name = "category.id")]
                                                List<int>? idCategory = null,
                                                [FromQuery(Name ="_deposit.max")]
                                                double? maxMoney = null,
                                                [FromQuery(Name ="_deposit.min")]
                                                double? minMoney = null,
                                                [FromQuery(Name ="is_featured")]
            bool? isFeatured = null)
        {
            BaseResponse<List<ProductModel>> response;
            try
            {
                var data = await _productService.GetList(pageIndex, pageSize, sorted, orders, name, idBrand, idCategory, 1, maxMoney, minMoney,isFeatured);
                response = new BaseResponse<List<ProductModel>>("Get Product successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<ProductModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost(Endpoints.ProductsController.product)]
        public async Task<IActionResult> CreateProduct([FromBody] CreatedProductDto productDto)
        {
            BaseResponse<ProductModel> response;
            try
            {
                var mapping = _mapper.Map<ProductModel>(productDto);
                var result = await _productService.CreateProduct(mapping);
                response = new BaseResponse<ProductModel>("Product:", HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<ProductModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet(Endpoints.ProductsController.productDetail)]
        public async Task<IActionResult> GetProductbyId([FromRoute] int id)
        {
            BaseResponse<ProductModel> response;
            try
            {
                var result = await _productService.GetById(id);
                if (result == null) response = new BaseResponse<ProductModel>("Can not found", HttpStatusCode.NotFound, null);
                else response = new BaseResponse<ProductModel>("Product:", HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<ProductModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPatch("products/{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto product, [FromRoute] int id)
        {
            BaseResponse<ProductModel> response;
            try
            {
                var productModel = new ProductModel()
                {
                    ID = id,
                    AvailableQuantity = product.AvailableQuantity,
                    Deposit = product.Deposit,
                    Description = product.Description,
                    IdBrand = product.IdBrand,
                    IdCategory = product.IdCategory,
                    IsFeatured = product.IsFeatured,
                    IsUsed = product.IsUsed,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Size = product.Size,
                    Status = product.Status,
                    Type = product.Type,
                    Images = product.Images?.Select(x => _mapper.Map<ImageModel>(x)).ToList()
                };
                productModel.Images?.ForEach(x => x.IdProduct = id);
                var result = await _productService.UpdateProduct(productModel);

                response = new BaseResponse<ProductModel>("Product:", HttpStatusCode.OK, result);
            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<ProductModel>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<ProductModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost("products/uploaded-files")]
        public async Task<IActionResult> UpdateFiles(List<IFormFile> files)
        {
            BaseResponse<List<string>> response;
            try
            {

                var result = await _productService.UploadFiles(files);
                response = new BaseResponse<List<string>>("Product:", HttpStatusCode.OK, result);
            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<List<string>>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<string>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost("products/uploaded-file")]
        public async Task<IActionResult> UpdateFile(IFormFile file)
        {
            BaseResponse<string> response;
            try
            {

                var result = await _productService.UploadFile(file);
                response = new BaseResponse<string>("Product:", HttpStatusCode.OK, result);
            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<string>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<string>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("products/customer-package/{customerPackageId}")]
        public async Task<IActionResult> GetProductByCustomerPackageId([FromRoute]int customerPackageId)
        {
            BaseResponse<List<ProductModel>> response;
            try
            {
                var result = await _productService.GetProductsByCustomerPackage(customerPackageId);
                response = new BaseResponse<List<ProductModel>>("Products in customer package:", HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<ProductModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
    }
}