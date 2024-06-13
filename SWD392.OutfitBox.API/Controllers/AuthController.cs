using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Helpers;
using SWD392.OutfitBox.BusinessLayer.Models.Requests;

using SWD392.OutfitBox.BusinessLayer.Models.Responses.Auth;
using SWD392.OutfitBox.BusinessLayer.Services.FirebaseService;
using SWD392.OutfitBox.BusinessLayer.Services.AuthService;
using SWD392.OutfitBox.DataLayer.Repositories;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Auth;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using System.Runtime.CompilerServices;
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
        public async Task<ActionResult<LoginFirebaseResponseDTO>> VerifyGoogleAccount([FromQuery] string accessToken)
        {
            var result = await _firebase.VerifyFirebaseThirdPartToken(accessToken);
            return Ok(result);
        }
        [HttpGet("auth/admin/{email}/{password}")]
        public async Task<ActionResult<BaseResponse<LoginSystemResponseDTO>>> LoginSystem([FromRoute] string email , [FromRoute] string password)
        {
            var request = new LoginSystemRequestDTO()
            {
                Email = email,
                Password = password
            };
            BaseResponse<LoginSystemResponseDTO> response;
            try
            {
                var data= await _authService.LoginSystem(request);
                if (data.Token == null) response = new BaseResponse<LoginSystemResponseDTO>("Email or password is wrong. Please check again.", System.Net.HttpStatusCode.BadRequest, null);
                else response = new BaseResponse<LoginSystemResponseDTO>("Login successfully.", System.Net.HttpStatusCode.OK, data);
            }catch(Exception ex)
            {
                response = new BaseResponse<LoginSystemResponseDTO>(ex.Message, System.Net.HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode,response);
        }
        [HttpGet("auth/partners/{email}/{password}")]
        public async Task<ActionResult<BaseResponse<LoginPartnerResponseDTO>>> LoginPartner([FromRoute] string email, [FromRoute] string password)
        {
            var request = new LoginPartnerRequestDTO()
            {
                Email = email,
                Password = password
            };
            BaseResponse<LoginPartnerResponseDTO> response;
            try
            {
                var data = await _authService.LoginPartner(request);
                if (data.Token == null) response = new BaseResponse<LoginPartnerResponseDTO>("Email or password is wrong. Please check again.", System.Net.HttpStatusCode.BadRequest, null);
                else response = new BaseResponse<LoginPartnerResponseDTO>("Login successfully.", System.Net.HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<LoginPartnerResponseDTO>(ex.Message, System.Net.HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }

    }
}
