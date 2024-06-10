using Microsoft.IdentityModel.Tokens;
using RTools_NTS.Util;
using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Helpers
{
    public class AuthHelper
    {

        public static JwtSecurityToken GetToken(Customer user)
        {
            List<Claim> authClaims = new List<Claim>
            {
                 new Claim(ClaimTypes.Name, user.Name),
                 new Claim(ClaimTypes.Email, user.Email),
                 new Claim(ClaimTypes.NameIdentifier, user.Name),
                 new Claim(ClaimTypes.Role, "Customer"),
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JWTAuthenticationHIGHsecuredPasswordVVVp1OH7Xzyr"));

            var token = new JwtSecurityToken(

                issuer: "outfit4rent.online",
                audience: "outfit4rent.online",
                claims: authClaims,
                expires: DateTime.Now.AddDays(3),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }

        public static ClaimsPrincipal DecodeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("JWTAuthenticationHIGHsecuredPasswordVVVp1OH7Xzyr");

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "outfit4rent.online",
                    ValidAudience = "outfit4rent.online",
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var claimsIdentity = new ClaimsIdentity(jwtToken.Claims);

                return new ClaimsPrincipal(claimsIdentity);
            }
            catch (Exception ex)
            {
                // Xử lý trường hợp token không hợp lệ
                Console.WriteLine($"Token validation failed: {ex.Message}");
                return null;
            }
        }

    }
}
