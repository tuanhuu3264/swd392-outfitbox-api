using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.Core.Services.ItemInUserPackage;

namespace SWD392.OutfitBox.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsInUserPackagesController : ControllerBase
    {
        readonly IItemsInUserPackageService _itemsInUserPackageService;
        public ItemsInUserPackagesController(IItemsInUserPackageService itemsInUserPackageService)
        {
            _itemsInUserPackageService = itemsInUserPackageService;
        }
        [HttpGet(ItemInUserPackageEndPoints.ItemInUserPackages)]
        public async Task<ActionResult> GetAll()
        {
            var result = await _itemsInUserPackageService.GetAll();
            return StatusCode((int)result.StatusCode, result.Data);
        }
    }
}
