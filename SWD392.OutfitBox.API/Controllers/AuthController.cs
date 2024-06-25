using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SWD392.OutfitBox.API.Controllers.Endpoints;

using SWD392.OutfitBox.BusinessLayer.Services.FirebaseService;
using SWD392.OutfitBox.BusinessLayer.Services.AuthService;

using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using System.Runtime.CompilerServices;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IAuthService _authService { get; set; }
        public IFirebaseService _firebase { get; set; }
        public AuthController(IAuthService authService, IFirebaseService firebaseService)
        {
            _authService = authService;
            _firebase = firebaseService;
        }
        
        [HttpGet(AuthEndpoints.VerifyThirdPartyInFirebaseToken)]
        public async Task<ActionResult<LoginModel>> VerifyGoogleAccount([FromQuery] string accessToken)
        {
            var result = await _firebase.VerifyFirebaseThirdPartToken(accessToken);
            return Ok(result);
        }
        [HttpGet("auth/admin/{email}/{password}")]
        public async Task<ActionResult<BaseResponse<LoginModel>>> LoginSystem([FromRoute] string email , [FromRoute] string password)
        {
            BaseResponse<LoginModel> response;
            try
            {
                var data= await _authService.LoginSystem(email,password);
                if (data.Token == null) response = new BaseResponse<LoginModel>("Email or password is wrong. Please check again.", System.Net.HttpStatusCode.BadRequest, null);
                else response = new BaseResponse<LoginModel>("Login successfully.", System.Net.HttpStatusCode.OK, data);
            }catch(Exception ex)
            {
                response = new BaseResponse<LoginModel>(ex.Message, System.Net.HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode,response);
        }
        [HttpGet("auth/partners/{email}/{password}")]
        public async Task<ActionResult<BaseResponse<LoginModel>>> LoginPartner([FromRoute] string email, [FromRoute] string password)
        {

            BaseResponse<LoginModel> response;
            try
            {
                var data = await _authService.LoginPartner(email,password);
                if (data.Token == null) response = new BaseResponse<LoginModel>("Email or password is wrong. Please check again.", System.Net.HttpStatusCode.BadRequest, null);
                else response = new BaseResponse<LoginModel>("Login successfully.", System.Net.HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<LoginModel>(ex.Message, System.Net.HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }

    }
}
