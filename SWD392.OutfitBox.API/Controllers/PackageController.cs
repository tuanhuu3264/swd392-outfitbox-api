using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Agreement.JPake;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.API.DTOs.Package;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.Services.CategoryPackageService;
using SWD392.OutfitBox.BusinessLayer.Services.PackageService;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using System.Net;

namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class PackageController : ControllerBase
    {
        public IPackageService _packageService;
        public ICategoryPackageService _categoryPackageService;
        public IMapper _mapper;
        public PackageController(ICategoryPackageService categoryPackageService, IPackageService packageService, IMapper mapper)
        {
            _packageService = packageService;
            _categoryPackageService = categoryPackageService;
            _mapper = mapper;
        }

        [HttpGet(PackageEndPoints.GetAllPackages)]
        public async Task<ActionResult<BaseResponse<List<PackageModel>>>> GetAllPackages()
        {
            BaseResponse<List<PackageModel>> response;
            try
            {
                var data = await _packageService.GetAllPackages();
                response = new BaseResponse<List<PackageModel>>("Get packages successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<PackageModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("packages/featured-packages")]
        public async Task<ActionResult<BaseResponse<List<PackageModel>>>> GetFeaturedPackages()
        {
            BaseResponse<List<PackageModel>> response;
            try
            {
                var data = await _packageService.GetFeaturedPackages();
                response = new BaseResponse<List<PackageModel>>("Get packages successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<PackageModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("packages/actived-packages")]
        public async Task<ActionResult<BaseResponse<PackageModel>>> GetAllEnabledPackages()
        {
            BaseResponse<List<PackageModel>> response;
            try
            {
                var data = await _packageService.GetAllEnabledPackages();
                response = new BaseResponse<List<PackageModel>>("Get enabled packages successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<PackageModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("packages/{id}")]
        public async Task<ActionResult<PackageModel>> GetPackageById([FromRoute] int id)
        {
            BaseResponse<PackageModel> response;
            try
            {
               
                var data = await _packageService.GetPackageById(id);
                response = new BaseResponse<PackageModel>("Get package successfully.", HttpStatusCode.Accepted, data);
            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<PackageModel>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<PackageModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost(PackageEndPoints.CreatePackage)]
        public async Task<ActionResult<BaseResponse<PackageModel>>> CreatePackage([FromBody] CreatePackageRequestDTO cratePackageRequestDTO)
        {
            BaseResponse<PackageModel> response;
            try
            {   
                var mapping = _mapper.Map<PackageModel>(cratePackageRequestDTO);
                var categoryPackageList = cratePackageRequestDTO.CategoryPackages?.Select(x => _mapper.Map<CategoryPackageModel>(x)).ToList();
                var data = await _packageService.CreatePackage(mapping, categoryPackageList);
                
                response = new BaseResponse<PackageModel>("Create package successfully.", HttpStatusCode.Created, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<PackageModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPatch("packages/{id}")]
        public async Task<ActionResult<PackageModel>> UpdatePackage([FromRoute] int id,[FromBody] UpdatePackageRequestDTO updatePackageRequestDTO)
        {
            BaseResponse<PackageModel> response;
            try
            {
                var mapping = _mapper.Map<PackageModel>(updatePackageRequestDTO);
                mapping.Id = id;
                var data = await _packageService.UpdatePackage(mapping);
                response = new BaseResponse<PackageModel>("Update package successfully.", HttpStatusCode.Accepted, data);
            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<PackageModel>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<PackageModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPatch(PackageEndPoints.ChangeStatus)]
        public async Task<ActionResult<PackageModel>> ActiveOrDeactivePackage([FromRoute] int id, [FromRoute] int status)
        {
            BaseResponse<PackageModel> response;
            try
            {
                var data = await _packageService.ChangeStatus(id, status);
                response = new BaseResponse<PackageModel>("Update package successfully.", HttpStatusCode.Accepted, data);
            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<PackageModel>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<PackageModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost("packages/uploaded-file")]
        public async Task<IActionResult> UpdateFile(IFormFile file)
        {
            BaseResponse<string> response;
            try
            {

                var result = await _packageService.UploadFile(file);
                response = new BaseResponse<string>("Package:", HttpStatusCode.OK, result);
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
        [HttpGet("packages/{id}")]
        public async Task<ActionResult<PackageModel>> GetPackage([FromRoute] int id)
        {
            BaseResponse<PackageModel> response;
            try
            { 
                var data = await _packageService.GetPackageById(id);
                response = new BaseResponse<PackageModel>("Get package successfully.", HttpStatusCode.OK, data);
            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<PackageModel>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<PackageModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
