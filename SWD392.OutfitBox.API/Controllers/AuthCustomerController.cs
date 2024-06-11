using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Helpers;
using SWD392.OutfitBox.BusinessLayer.Models.Requests;

using SWD392.OutfitBox.BusinessLayer.Models.Responses.Auth;
using SWD392.OutfitBox.BusinessLayer.Services.FirebaseService;
using SWD392.OutfitBox.BusinessLayer.Services.AuthService;
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
        
        [HttpGet(AuthEndpoints.VerifyThirdPartyInFirebaseToken)]
        public async Task<ActionResult<LoginResponseDTO>> VerifyGoogleAccount([FromQuery] string accessToken)
        {
            var result = await _firebase.VerifyFirebaseThirdPartToken(accessToken);
            return Ok(result);
        }

    }
}
