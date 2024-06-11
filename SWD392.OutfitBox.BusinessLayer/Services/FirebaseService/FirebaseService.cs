using Firebase.Auth;
using FirebaseAdmin.Auth;
using FirebaseAdmin.Messaging;
using Google.Api.Gax;
using SWD392.OutfitBox.BusinessLayer.Helpers;
using SWD392.OutfitBox.BusinessLayer.Models.Requests;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Auth;
using SWD392.OutfitBox.BusinessLayer.Helpers;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.FirebaseService
{
    public class FirebaseService : IFirebaseService
    {

        private readonly ICustomerRepository _customerRepository;

        public FirebaseService(ICustomerRepository customerRepository)
        {

            _customerRepository = customerRepository;
        }

        public async Task<LoginResponseDTO> VerifyFirebaseThirdPartToken(string accessToken)
        {
            var result = await DecodeFirebaseToken(accessToken);
            var customer = await _customerRepository.GetCustomerByPhoneOrEmail(result.Email.ToLower());

            if (customer == null)
            {
                var newCustomer = new Customer
                {
                    Email = result.Email,
                    Name = result.Name == null ? $"User {DateTime.Now.ToString("HHmmyyyy")}" : result.Name,
                    Status = 1,
                    MoneyInWallet = 0,
                    Password = "12345",
                    Address = ""
                } ;
                var resultNewCustomer = await _customerRepository.Create(newCustomer);
                if (result.IsVerify == false)
                    return new LoginResponseDTO()
                    {
                        Message = "The account is not verified."
                    };
                var tokenHandler = AuthHelper.GetToken(resultNewCustomer);
                return new LoginResponseDTO()
                {
                    Message = "Success login!!",
                    Token = new JwtSecurityTokenHandler().WriteToken(tokenHandler),
                    Expiration = tokenHandler.ValidTo,
                    GUID=result.GUID,
                    Email = newCustomer.Email,
                    Name= newCustomer.Name,
                    CustomerId= newCustomer.Id,
                    Picture = result.Picture

                };
                
            }
            var tokenHandler2 = AuthHelper.GetToken(customer);
            return new LoginResponseDTO()
            {
                Message = "Success login!!",
                Token = new JwtSecurityTokenHandler().WriteToken(tokenHandler2),
                Expiration = tokenHandler2.ValidTo,
                GUID = result.GUID,
                Email = result.Email,
                Name = result.Name,
                Picture = result.Picture,
                CustomerId = customer.Id,
            };


        }

        private async Task<FirebaseAuthModels> DecodeFirebaseToken(string accessToken)
        {

            var result = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(accessToken);
            if (result == null)
            {
                throw new Exception("Invalid Firebase token.");
            }

            string uid = result.Uid;

            // Extract user information and create LoginResponseDTO
            var claims = result.Claims;
            var userId = claims.ContainsKey("user_id") ? claims["user_id"].ToString() : null;
            var email = claims.ContainsKey("email") ? claims["email"].ToString() : null;
      
            var picture = claims.ContainsKey("picture") ? claims["picture"].ToString() : null;
            var signInProvider = claims.ContainsKey("sign_in_provider") ? claims["sign_in_provider"].ToString() : null;
            var isVerify = claims.ContainsKey("email_verified") ? bool.Parse(claims["email_verified"].ToString()) : false;
            var name = claims.ContainsKey("name") ? claims["name"].ToString() : null;
            return new FirebaseAuthModels
            {
                GUID = userId,
                Email = email,
                IsVerify = isVerify,
             
                Picture = picture,
                SignInProvider = signInProvider,
                Name = name
            };
        }


        public async Task<LoginResponseDTO> VerifyFirebaseNormalToken(string accessToken)
        {
            var result = await DecodeFirebaseToken(accessToken);

            if (result.IsVerify == false)
                return new LoginResponseDTO()
                {
                    Message = "The account is not verified."
                };
            var customer = await _customerRepository.GetCustomerByPhoneOrEmail(result.Email.ToLower());

            if (customer == null)
            {
                var newCustomer = new Customer
                {
                    Email = result.Email,
                    Name = result.Name == null ? $"User {DateTime.Now.ToString("HHmmyyyy")}" : result.Name,
                    Status = 1,
                    MoneyInWallet = 0,
                    Password = "12345",
                    Address = ""
                };
                var resultNewCustomer = await _customerRepository.Create(newCustomer);
                var tokenHandler = AuthHelper.GetToken(resultNewCustomer);
                return new LoginResponseDTO()
                {
                    Message = "Success login!!",
                    Token = new JwtSecurityTokenHandler().WriteToken(tokenHandler),
                    Expiration = tokenHandler.ValidTo,
                    GUID = result.GUID,
                    Email = result.Email,
                    Name = result.Name,

                    Picture = result.Picture

                };

            }
            var tokenHandler2 = AuthHelper.GetToken(customer);
            return new LoginResponseDTO()
            {
                Message = "Success login!!",
                Token = new JwtSecurityTokenHandler().WriteToken(tokenHandler2),
                Expiration = tokenHandler2.ValidTo,
                GUID = result.GUID,
                Email = result.Email,
                Name = result.Name,
                Picture = result.Picture

            };


        }
    }
}
