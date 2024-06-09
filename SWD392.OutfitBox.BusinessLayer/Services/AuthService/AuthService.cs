using AutoMapper;
using FirebaseAdmin.Auth;
using SWD392.OutfitBox.BusinessLayer.Exceptions.Auth;
using SWD392.OutfitBox.BusinessLayer.Models.Requests;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Auth;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Auth;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Customer;
using SWD392.OutfitBox.Core.Helpers;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Interfaces;
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
        public ICustomerRepository _customerRepository { get; set; }
        public AuthService(IMapper mapper, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<ForgetPasswordResponseDTO> ForgetPassword(ForgetPasswordRequestDTO forgetPasswordRequestDTO)
        {
            var customer = await _customerRepository.GetCustomerByPhoneOrEmail(forgetPasswordRequestDTO.Email);
            customer.OTP = long.Parse(DateTime.Now.ToString("HHmmss"));
            await _customerRepository.UpdateCustomer(customer);
            return new ForgetPasswordResponseDTO() { UserId = customer.Id, Message= "OTP is generated and sent to customer's mail." };
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var customer = await _customerRepository.GetCustomerByPhoneOrEmail(loginRequestDTO.EmailOrPhone);
            if (customer != null && customer.Status == 0)
                return new LoginResponseDTO()
                {
                    Message = "User is banned or not verified."
                };
            if (customer != null && loginRequestDTO.Password == customer.Password)
            {
                var tokenSecurity = AuthHelper.GetToken(customer);
                var token = new JwtSecurityTokenHandler().WriteToken(tokenSecurity);
                var expiration = tokenSecurity.ValidTo;

                return new LoginResponseDTO()
                {
                    Token = token.ToString(),
                    Expiration = expiration,
                    Message = "Login successfully."
                };
            }
            return new LoginResponseDTO()
            {
                Token = "",
                Expiration = DateTime.Now,
                Message = AuthExceptions.EMS01
            };
        }

        public async Task<RegisterUserResponseDTO> Register(RegisterUserRequestDTO registerRequestDTO)
        {
            var customer = new DataLayer.Entities.Customer()
            {
                Email = registerRequestDTO.Email,
                Phone = registerRequestDTO.Phone,
                Password = registerRequestDTO.Password,
                Name = registerRequestDTO.UserName,
                Address = registerRequestDTO.Address,
                Status = 1,
                OTP = long.Parse(DateTime.Now.ToString("HHmmss"))
            };
            var createdUser = await _customerRepository.Create(customer);
            return new RegisterUserResponseDTO()
            {
                Message = "Create Successfully. Need to verify.",
                UserId = customer.Id

            };
        }

        public async Task<VerifyOTPResponseDTO> VerifyOTP(VerifyOTPRequestDTO verifyOTPRequestDTO)
        {
            var customer = await _customerRepository.GetCustomerById(verifyOTPRequestDTO.UserId);
            if (customer == null) return new VerifyOTPResponseDTO()
            {
                Message = "Error to find customer to verify OTP"
            };
            if (customer.OTP == verifyOTPRequestDTO.OTP)
            {   
                return new VerifyOTPResponseDTO()
                {
                    Message = "Verify account successfully!",
                    UserProfile = _mapper.Map<CustomerDTO>(customer)
                };
            }
            customer.OTP = -1;
            await _customerRepository.UpdateCustomer(customer);
            return new VerifyOTPResponseDTO()
            {
                Message = AuthExceptions.EMS03
                            
            };
        }

        public async Task<ResetPasswordResponseDTO> ResetPassword(ResetPasswordRequestDTO resetPasswordRequestDTO)
        {
            var customer = await _customerRepository.GetCustomerById(resetPasswordRequestDTO.Id);
            customer.Password = resetPasswordRequestDTO.NewPassword;
            await _customerRepository.UpdateCustomer(customer);
            return new ResetPasswordResponseDTO()
            {
                CustomerId = customer.Id,
                Message = "Reset Password Successfully"
            };
        }

        public Task<LoginResponseDTO> LoginFirebase(string accessToken)
        {
            throw new NotImplementedException();
        }

       
    }
}
