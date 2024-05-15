using SWD392.OutfitBox.Core.Models.Requests;
using SWD392.OutfitBox.Core.Models.Requests.Auth;
using SWD392.OutfitBox.Core.Models.Responses.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.AuthService
{
    public interface IAuthService
    {
        public Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        public Task<RegisterUserResponseDTO> Register(RegisterUserRequestDTO registerRequestDTO);
        public Task<VerifyOTPResponseDTO> VerifyOTP(VerifyOTPRequestDTO verifyOTPRequestDTO);

        public Task<ForgetPasswordResponseDTO> ForgetPassword(ForgetPasswordRequestDTO forgetPasswordRequestDTO);
    }
}
