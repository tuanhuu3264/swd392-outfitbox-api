using Firebase.Auth;
using Firebase.Auth.Providers;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Configuration;
using System.Text.Json;

namespace SWD392.OutfitBox.API.Configurations.Firebase
{
    public static class FirebaseConfiguration
    {

        public static void AddJWTFirebase(this IServiceCollection services, IConfiguration configuration)
        {

            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = $"https://securetoken.google.com/{configuration["firebase:project-name"]}";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = $"https://securetoken.google.com/{configuration["firebase:project-name"]}",
                        ValidateAudience = true,
                        ValidAudience = configuration["firebase:project-name"],
                        ValidateLifetime = true
                    };
                });
        }

        public static void CreateFirebaseApp(this IConfiguration configuration)
        {
        //    FirebaseApp.Create(new AppOptions
        //    {
        //        Credential = GoogleCredential.FromFile(configuration["FirebaseAdmin:Path"]),
        //        ProjectId = configuration["FirebaseAdmin:ProjectId"]

        //    });
       }
    }
}
