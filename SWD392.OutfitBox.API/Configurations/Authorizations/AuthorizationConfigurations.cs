using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SWD392.OutfitBox.API.Configurations.Authorizations
{
    public static class AuthorizationConfigurations
    {
        public static void AddJwtAuthorization(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.SaveToken = true;
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidAudience = configuration["JWT:ValidAudience"],
                       ValidIssuer = configuration["JWT:ValidIssuer"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))

                   };
               });

        }

        public static void AddOauth(this IServiceCollection service, IConfiguration configuration)
        {

        }
    }
}
