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
                response = new BaseResponse<List<ProductGeneral>>("Get Product successfully.", HttpStatusCode.OK, data.Data);
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
            var result = await _productService.CreateProduct(productDto);
            return StatusCode((int)result.StatusCode, result.Message);
        }

        [HttpGet(Endpoints.ProductsController.productDetail)]
        public async Task<IActionResult> GetProductbyId([FromRoute] int id)
        {
            var result = await _productService.GetById(id);
            return StatusCode((int)result.StatusCode, result.Data != null ? result.Data : result.Message);
        }
        [HttpPut(Endpoints.ProductsController.product)]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto product)
        {
            var result = await _productService.UpdateProduct(product);
            return StatusCode((int)result.StatusCode, result.Data ? result.Data : result.Message );
        }
    }
}