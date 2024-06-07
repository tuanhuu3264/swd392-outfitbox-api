using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Package;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Package;
using SWD392.OutfitBox.Core.Models.Responses.Package;
using SWD392.OutfitBox.Core.Services.PackageService;

namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class PackageController : ControllerBase
    {
        public IPackageService _packageService; 
        public PackageController(IPackageService packageService) 
        { 
        _packageService = packageService;
        }

        [HttpGet(PackageEndPoints.GetAllPackages)]
        public async Task<ActionResult<PackageDTO>> GetAllPackages()
        {
            return Ok(await _packageService.GetAllPackages());
        }

        [HttpGet(PackageEndPoints.GetAllEnabledPackages)]
        public async Task<ActionResult<PackageDTO>> GetAllEnabledPackages()
        {
            return Ok(await _packageService.GetAllEnabledPackages());
        }
        [HttpPost(PackageEndPoints.CreatePackage)]
        public async Task<ActionResult<CreatePackageResponseDTO>> CreatePackage([FromBody] CreatePackageRequestDTO cratePackageRequestDTO)
        {
            var result = await _packageService.CreatePackage(cratePackageRequestDTO);
            return Ok(result);
        }
        [HttpPut(PackageEndPoints.UpdatePackage)]
        public async Task<ActionResult<UpdatePackageResponseDTO>> UpdatePackage([FromBody] UpdatePackageRequestDTO updatePackageRequestDTO)
        {
            var result = await _packageService.UpdatePackage(updatePackageRequestDTO);
            return Ok(result);
        }
        [HttpPut(PackageEndPoints.ActiveOrDeactivePackage)]
        public async Task<ActionResult<PackageDTO>> ActiveOrDeactivePackage([FromRoute] int id)
        {
            var result = await _packageService.ActiveOrDeactivePackageById(id);
            return Ok(result);
        }
    }
}
