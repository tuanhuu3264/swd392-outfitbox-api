using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.Core.Models.Requests.Product;
using SWD392.OutfitBox.Core.Services.ProductService;

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
            var result = await _productService.GetAll();
            return StatusCode((int)result.StatusCode, result.Data);
        }
        [HttpPost(Endpoints.ProductsController.product)]
        public async Task<IActionResult> CreateProduct([FromBody]CreatedProductDto productDto )
        {
            var result = await _productService.CreateProduct(productDto);
            return StatusCode((int)result.StatusCode, result.Message);
        }
    }
}