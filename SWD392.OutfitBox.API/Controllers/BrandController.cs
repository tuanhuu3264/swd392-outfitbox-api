using FirebaseAdmin.Auth.Multitenancy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Brand;
using SWD392.OutfitBox.BusinessLayer.Services.BrandRepository;

namespace SWD392.OutfitBox.API.Controllers
{
    
    [ApiController]
    public class BrandController : ControllerBase
    {
        public IBrandService _branchService; 
        public BrandController(IBrandService branchService)
        {
            _branchService = branchService;
        }
        [HttpGet("brands")]
        public async Task<ActionResult<BaseResponse<List<BrandDTO>>>> GetAllBrands()
        {
            BaseResponse<List<BrandDTO>> response;
            try
            {
                var data = await _branchService.GetAllBrands();
                response = new BaseResponse<List<BrandDTO>>("Get brands successfully.", System.Net.HttpStatusCode.OK, data); 
            }catch(Exception ex)
            {
                response = new BaseResponse<List<BrandDTO>>(ex.Message, System.Net.HttpStatusCode.InternalServerError, null); 
            }
            return StatusCode((int)response.StatusCode,response);
        }
    }
}
