using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Helpers;
using SWD392.OutfitBox.BusinessLayer.Models.Requests;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Auth;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Auth;
using SWD392.OutfitBox.BusinessLayer.Services.FirebaseService;
using SWD392.OutfitBox.Core.Services.AuthService;

namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class AuthCustomerController : ControllerBase
    {
        public IAuthService _authService { get; set; }
        public IFirebaseService _firebase { get; set; }
        public AuthCustomerController(IAuthService authService, IFirebaseService firebaseService)
        {
            _authService = authService;
            _firebase = firebaseService;
        }
        [HttpGet(AuthEndpoints.Login)]
        public async Task<ActionResult<LoginResponseDTO>> Login([FromQuery] string emailOrPhone, [FromQuery] string password)
        {
            var loginRequest = new LoginRequestDTO()
            {
                Password = password,
                EmailOrPhone = emailOrPhone
            };
            var result = await _authService.Login(loginRequest);
            return Ok(result);
        }
        [HttpPost(AuthEndpoints.Register)]
        public async Task<ActionResult<RegisterUserResponseDTO>> Register([FromBody] RegisterUserRequestDTO registerUserRequestDTO)
        {
            var result = await _authService.Register(registerUserRequestDTO);
            return Ok(result);
        }
        [HttpPost(AuthEndpoints.ForgetPassword)]
        public async Task<ActionResult<ForgetPasswordResponseDTO>> ForgetPassword([FromBody] ForgetPasswordRequestDTO forgetPasswordRequestDTO)
        {
            var result = await _authService.ForgetPassword(forgetPasswordRequestDTO);
            return Ok(result);
        }
        [HttpPut(AuthEndpoints.VerifyOTP)]
        public async Task<ActionResult<VerifyOTPResponseDTO>> VerifyOTP([FromBody] VerifyOTPRequestDTO verifyOTPRequestDTO)
        {
            var result = await _authService.VerifyOTP(verifyOTPRequestDTO);
            return Ok(result);
        }
        [HttpGet(AuthEndpoints.VerifyThirdPartyInFirebaseToken)]
        public async Task<ActionResult<FirebaseAuthModels>> VerifyGoogleAccount([FromQuery] string accessToken)
        {
            var result = await _firebase.VerifyFirebaseThirdPartToken(accessToken);
            return Ok(result);
        }

    }
}
