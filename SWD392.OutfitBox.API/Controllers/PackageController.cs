using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Package;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Package;
using SWD392.OutfitBox.BusinessLayer.Services.PackageService;
using SWD392.OutfitBox.Core.Models.Responses.Package;
using System.Net;

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
        public async Task<ActionResult<BaseResponse<List<PackageDTO>>>> GetAllPackages()
        {
            BaseResponse<List<PackageDTO>> response;
            try
            {   
                var data = await _packageService.GetAllPackages();
                response = new BaseResponse<List<PackageDTO>>("Get packages successfully.",HttpStatusCode.OK,data);
            }catch(Exception ex)
            {
                response = new BaseResponse<List<PackageDTO>>(ex.Message,HttpStatusCode.InternalServerError,null);
            }
            return StatusCode((int)response.StatusCode,response);
        }

        [HttpGet(PackageEndPoints.GetAllEnabledPackages)]
        public async Task<ActionResult<BaseResponse<PackageDTO>>> GetAllEnabledPackages()
        {
            BaseResponse<List<PackageDTO>> response;
            try
            {
                var data = await _packageService.GetAllEnabledPackages();
                response = new BaseResponse<List<PackageDTO>>("Get enabled packages successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<PackageDTO>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost(PackageEndPoints.CreatePackage)]
        public async Task<ActionResult<BaseResponse<CreatePackageResponseDTO>>> CreatePackage([FromBody] CreatePackageRequestDTO cratePackageRequestDTO)
        {
            BaseResponse<CreatePackageResponseDTO> response;
            try
            {
                var data = await _packageService.CreatePackage(cratePackageRequestDTO);
                response = new BaseResponse<CreatePackageResponseDTO>("Create package successfully.", HttpStatusCode.Created, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CreatePackageResponseDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPut(PackageEndPoints.UpdatePackage)]
        public async Task<ActionResult<UpdatePackageResponseDTO>> UpdatePackage([FromBody] UpdatePackageRequestDTO updatePackageRequestDTO)
        {
            BaseResponse<UpdatePackageResponseDTO> response;
            try
            {
                var data = await _packageService.UpdatePackage(updatePackageRequestDTO);
                response = new BaseResponse<UpdatePackageResponseDTO>("Update package successfully.", HttpStatusCode.Accepted, data);
            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<UpdatePackageResponseDTO>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<UpdatePackageResponseDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPut(PackageEndPoints.ActiveOrDeactivePackage)]
        public async Task<ActionResult<PackageDTO>> ActiveOrDeactivePackage([FromRoute] int id)
        {
            BaseResponse<PackageDTO> response;
            try
            {
                var data = await _packageService.ActiveOrDeactivePackageById(id);
                response = new BaseResponse<PackageDTO>("Update package successfully.", HttpStatusCode.Accepted, data);
            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<PackageDTO>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<PackageDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
