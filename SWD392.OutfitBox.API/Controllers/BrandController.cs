using Azure;
using FirebaseAdmin.Auth.Multitenancy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Brand;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Brand;

using SWD392.OutfitBox.BusinessLayer.Services.BrandRepository;
using System.Net;

namespace SWD392.OutfitBox.API.Controllers
{
    
    [ApiController]
    public class BrandController : ControllerBase
    {
        public IBrandService _brandService; 
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet("brands")]
        public async Task<ActionResult<BaseResponse<List<BrandDTO>>>> GetAllBrands()
        {
            BaseResponse<List<BrandDTO>> response;
            try
            {
                var data = await _brandService.GetAllBrands();
                response = new BaseResponse<List<BrandDTO>>("Get brands successfully.", System.Net.HttpStatusCode.OK, data); 
            }catch(Exception ex)
            {
                response = new BaseResponse<List<BrandDTO>>(ex.Message, System.Net.HttpStatusCode.InternalServerError, null); 
            }
            return StatusCode((int)response.StatusCode,response);
        }

        [HttpGet("brands/{id}")]
        public async Task<ActionResult<BaseResponse<BrandDTO>>> GetBrandById([FromRoute] int id)
        {
            BaseResponse<BrandDTO> response;
            try
            {
                var data = await _brandService.GetBrandById(id);
                response = new BaseResponse<BrandDTO>("Get brand successfully.", HttpStatusCode.OK, data);
            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<BrandDTO>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<BrandDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost("brands")]
        public async Task<ActionResult<BaseResponse<CreateBrandResponseDTO>>> CreateBrand([FromBody] CreateBrandRequestDTO createBrandRequestDTO)
        {
            BaseResponse<CreateBrandResponseDTO> response;
            try
            {
                var data = await _brandService.CreateBrand(createBrandRequestDTO);
                response = new BaseResponse<CreateBrandResponseDTO>("Create brand successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CreateBrandResponseDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPatch("brands")]
        public async Task<ActionResult<BaseResponse<UpdateBrandResponseDTO>>> UpdateBrand([FromBody] UpdateBrandRequestDTO updateBrandRequestDTO)
        {
            BaseResponse<UpdateBrandResponseDTO> response;
            try
            {
                var data = await _brandService.UpdateBrand(updateBrandRequestDTO);
                response = new BaseResponse<UpdateBrandResponseDTO>("Update brand successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<UpdateBrandResponseDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPatch("brands/{id}/status/{status}")]
        public async Task<ActionResult<BaseResponse<BrandDTO>>>ChangeBrandStatus([FromRoute] int id, [FromRoute] int status)
        {
            BaseResponse<BrandDTO> response;
            try
            {
                var data = await _brandService.UpdateStatus(id,status);
                response = new BaseResponse<BrandDTO>("Update brand successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<BrandDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
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
    }
}
