using AutoMapper;
using Azure;
using FirebaseAdmin.Auth.Multitenancy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.DTOs.Brand;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.Services.BrandService;
using System.Net;

namespace SWD392.OutfitBox.API.Controllers
{

    [ApiController]
    public class BrandController : ControllerBase
    {
        public IBrandService _brandService;
        public IMapper _mapper;
        public BrandController(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }
        [HttpGet("brands")]
        public async Task<ActionResult<BaseResponse<List<BrandModel>>>> GetAllBrands()
        {
            BaseResponse<List<BrandModel>> response;
            try
            {
                var data = await _brandService.GetAllBrands();
                response = new BaseResponse<List<BrandModel>>("Get brands successfully.", System.Net.HttpStatusCode.OK, data); 
            }catch(Exception ex)
            {
                response = new BaseResponse<List<BrandModel>>(ex.Message, System.Net.HttpStatusCode.InternalServerError, null); 
            }
            return StatusCode((int)response.StatusCode,response);
        }

        [HttpGet("brands/{id}")]
        public async Task<ActionResult<BaseResponse<BrandModel>>> GetBrandById([FromRoute] int id)
        {
            BaseResponse<BrandModel> response;
            try
            {
                var data = await _brandService.GetBrandById(id);
                response = new BaseResponse<BrandModel>("Get brand successfully.", HttpStatusCode.OK, data);
            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<BrandModel>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<BrandModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost("brands")]
        public async Task<ActionResult<BaseResponse<BrandModel>>> CreateBrand([FromBody] CreateBrandRequestDTO createBrandRequestDTO)
        {
            BaseResponse<BrandModel> response;
            try
            {
                var mapping = _mapper.Map<BrandModel>(createBrandRequestDTO); 
                var data = await _brandService.CreateBrand(mapping);
                response = new BaseResponse<BrandModel>("Create brand successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<BrandModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPatch("brands/{id}")]
        public async Task<ActionResult<BaseResponse<BrandModel>>> UpdateBrand([FromRoute] int id, [FromBody] UpdateBrandRequestDTO updateBrandRequestDTO)
        {
            BaseResponse<BrandModel> response;
            try
            {
                var mapping = _mapper.Map<BrandModel>(updateBrandRequestDTO);
                mapping.ID= id;
                var data = await _brandService.UpdateBrand(mapping );
                response = new BaseResponse<BrandModel>("Update brand successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<BrandModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPatch("brands/{id}/status/{status}")]
        public async Task<ActionResult<BaseResponse<BrandModel>>>ChangeBrandStatus([FromRoute] int id, [FromRoute] int status)
        {
            BaseResponse<BrandModel> response;
            try
            {
                var data = await _brandService.UpdateStatus(id,status);
                response = new BaseResponse<BrandModel>("Update brand successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<BrandModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpDelete("brands/{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteBrand([FromRoute] int id)
        {
            BaseResponse<bool> response;
            try
            {
                var data = await _brandService.DeleteBrand(id);
                response = new BaseResponse<bool>("Delete brand successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<bool>(ex.Message, HttpStatusCode.InternalServerError, false);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost("brands/uploaded-file")]
        public async Task<IActionResult> UpdateFile(IFormFile file)
        {
            BaseResponse<string> response;
            try
            {

                var result = await _brandService.UploadBrandImage(file);
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
    }
}
