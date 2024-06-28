using Firebase.Auth;
using FirebaseAdmin.Auth;
using FirebaseAdmin.Messaging;
using Google.Api.Gax;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.Helpers;

using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FirebaseAuthException = FirebaseAdmin.Auth.FirebaseAuthException;

namespace SWD392.OutfitBox.BusinessLayer.Services.FirebaseService
{
    public class FirebaseService : IFirebaseService
    {

        private readonly ICustomerRepository _customerRepository;

        public FirebaseService(ICustomerRepository customerRepository)
        {

            _customerRepository = customerRepository;
        }

        public async Task<LoginModel> VerifyFirebaseThirdPartToken(string accessToken)
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
                    Picture = result.Picture,
                    Address = ""
                } ;
                var resultNewCustomer = await _customerRepository.Create(newCustomer);
                if (result.IsVerify == false)
                    throw new AuthenticationException("The account is verify.");
                var accessTokenHandler = AuthHelper.GetToken(customer, 1);
                var refreshTokenHandler = AuthHelper.GetToken(customer, 3);
                return new LoginModel()
                {
                    RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshTokenHandler),
                    Token = new JwtSecurityTokenHandler().WriteToken(accessTokenHandler),
                    Expiration = accessTokenHandler.ValidTo,
                    Guid = result.GUID,
                    Email = result.Email,
                    Picture = result.Picture,
                    Id = customer.Id,
                };

            }
            var accessTokenHandler2 = AuthHelper.GetToken(customer, 1);
            var refreshTokenHandler2 = AuthHelper.GetToken(customer, 3);
            return new LoginModel()
            {
                RefreshToken= new JwtSecurityTokenHandler().WriteToken(refreshTokenHandler2),
                Token = new JwtSecurityTokenHandler().WriteToken(accessTokenHandler2),
                Expiration = accessTokenHandler2.ValidTo,
                Guid = result.GUID,
                Email = result.Email,
                Picture = result.Picture,
                Id = customer.Id,
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


        public async Task<LoginModel> VerifyFirebaseNormalToken(string accessToken)
        {
            var result = await DecodeFirebaseToken(accessToken);

            if (result.IsVerify == false) throw new AuthenticationException("The account is not verify.");
            var customer = await _customerRepository.GetCustomerByPhoneOrEmail(result.Email.ToLower());

            if (customer == null)
            {
                var newCustomer = new Customer
                {
                    Email = result.Email,
                    Name = result.Name == null ? $"User {DateTime.Now.ToString("HHmmyyyy")}" : result.Name,
                    Status = 1,
                    MoneyInWallet = 0,

                    Address = ""
                };
                var accessTokenHandler = AuthHelper.GetToken(customer, 1);
                var refreshTokenHandler = AuthHelper.GetToken(customer, 3);
                return new LoginModel()
                {
                    RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshTokenHandler),
                    Token = new JwtSecurityTokenHandler().WriteToken(accessTokenHandler),
                    Expiration = accessTokenHandler.ValidTo,
                    Guid = result.GUID,
                    Email = result.Email,
                    Picture = result.Picture,
                    Id = customer.Id,
                };

            }
            var accessTokenHandler2 = AuthHelper.GetToken(customer, 1);
            var refreshTokenHandler2 = AuthHelper.GetToken(customer, 3);
            return new LoginModel()
            {
                RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshTokenHandler2),
                Token = new JwtSecurityTokenHandler().WriteToken(accessTokenHandler2),
                Expiration = accessTokenHandler2.ValidTo,
                Guid = result.GUID,
                Email = result.Email,
                Picture = result.Picture,
                Id = customer.Id,
            };


        }

        public Task<LoginModel> GetAccessTokenFromRefeshToken(string refreshToken)
        {
            /*try
            {
                var result = 
            }catch(Exception ex)
            {

            }*/
            throw new Exception();
        }
    }
}
