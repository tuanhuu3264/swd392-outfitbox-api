using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Product;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Area;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Partner;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Product;
using SWD392.OutfitBox.BusinessLayer.Services.ProductService;
using System.Net;

namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet(Endpoints.ProductsController.getAllProducts)]
        public async Task<IActionResult> GetAll()
        {
            //var result = await _productService.GetAll();
            //return StatusCode((int)result.StatusCode, result.Data);
            BaseResponse<List<ProductGeneral>> response;
            try
            {
                var data = await _productService.GetAll();
                response = new BaseResponse<List<ProductGeneral>>("Get Product successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<ProductGeneral>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost(Endpoints.ProductsController.product)]
        public async Task<IActionResult> CreateProduct([FromBody] CreatedProductDto productDto)
        {
            BaseResponse<ProductDetailDto> response;
            try
            {
                var result = await _productService.CreateProduct(productDto);
                if (result.Id <= 0) response = new BaseResponse<ProductDetailDto>("Can not found", HttpStatusCode.NotFound, null);
                else response = new BaseResponse<ProductDetailDto>("Product:", HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<ProductDetailDto>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet(Endpoints.ProductsController.productDetail)]
        public async Task<IActionResult> GetProductbyId([FromRoute] int id)
        {
            BaseResponse<ProductDetailDto> response;
            try
            {
                var result = await _productService.GetById(id);
                if (result.Id <= 0) response = new BaseResponse<ProductDetailDto>("Can not found",HttpStatusCode.NotFound,null);
                else response = new BaseResponse<ProductDetailDto>("Product:",HttpStatusCode.OK,result);
            }
            catch(Exception ex) {
                response = new BaseResponse<ProductDetailDto>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPut(Endpoints.ProductsController.product)]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto product)
        {
            BaseResponse<ProductDetailDto> response;
            try
            {
                var result = await _productService.UpdateProduct(product);
                response = new BaseResponse<ProductDetailDto>("Product:", HttpStatusCode.OK, result);
            }
            catch(ArgumentNullException ex)
            {
                response = new BaseResponse<ProductDetailDto>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<ProductDetailDto>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
    }
}