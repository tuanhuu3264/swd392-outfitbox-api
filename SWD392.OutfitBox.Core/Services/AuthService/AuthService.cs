using AutoMapper;
using SWD392.OutfitBox.Core.Exceptions.Auth;
using SWD392.OutfitBox.Core.Helpers;
using SWD392.OutfitBox.Core.Models.Requests;
using SWD392.OutfitBox.Core.Models.Requests.Auth;
using SWD392.OutfitBox.Core.Models.Responses.Auth;
using SWD392.OutfitBox.Core.Models.Responses.User;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.AuthService
{
    public class AuthService : IAuthService
    {
        public IMapper _mapper;
        public IUserRepository _userRepository { get; set; }
        public AuthService(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<ForgetPasswordResponseDTO> ForgetPassword(ForgetPasswordRequestDTO forgetPasswordRequestDTO)
        {
            var user = await _userRepository.GetUserByPhoneOrEmail(forgetPasswordRequestDTO.Email);
            user.OTP = long.Parse(DateTime.Now.ToString("HHmmss"));
            await _userRepository.UpdateUser(user);
            return new ForgetPasswordResponseDTO() { };
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = await _userRepository.GetUserByPhoneOrEmail(loginRequestDTO.EmailOrPhone);
            if (user != null && loginRequestDTO.Password == user.Password)
            {
                var tokenSecurity = AuthHelper.GetToken(user);
                var token = new JwtSecurityTokenHandler().WriteToken(tokenSecurity);
                var expiration = tokenSecurity.ValidTo;

                return new LoginResponseDTO()
                {
                    Token = token.ToString(),
                    Expiration = expiration,
                    Message = "Login successfully."
                };
            }
            if (user != null && user.Status == 0)
                return new LoginResponseDTO()
                {
                    Message = "User is banned or not verified."
                };
            return new LoginResponseDTO()
            {
                Token = "",
                Expiration = DateTime.Now,
                Message = AuthExceptions.EMS01
            };
        }

        public async Task<RegisterUserResponseDTO> Register(RegisterUserRequestDTO registerRequestDTO)
        {
            var user = new User()
            {
                Email = registerRequestDTO.Email,
                Phone = registerRequestDTO.Phone,
                Password = registerRequestDTO.Password,
                RoldeId = 1,
                Name = registerRequestDTO.UserName,
                Address = registerRequestDTO.Address,
                Status = 1,
                OTP = long.Parse(DateTime.Now.ToString("HHmmss"))
            };
            var createdUser = await _userRepository.Create(user);
            return new RegisterUserResponseDTO()
            {
                Message = "Create Successfully. Need to verify.",
                UserId = user.Id

            };
        }

        public async Task<VerifyOTPResponseDTO> VerifyOTP(VerifyOTPRequestDTO verifyOTPRequestDTO)
        {
            var user = await _userRepository.GetUserById(verifyOTPRequestDTO.UserId);
            if (user == null) return new VerifyOTPResponseDTO()
            {
                Message = "Error to find user to verify OTP"
            };
            if (user.OTP == verifyOTPRequestDTO.OTP)
            {   
                return new VerifyOTPResponseDTO()
                {
                    Message = "Verify account successfully!",
                    UserProfile = _mapper.Map<UserDTO>(user)
                };
            }
            return new VerifyOTPResponseDTO()
            {
                Message = AuthExceptions.EMS03

            };
        }
    }
}
