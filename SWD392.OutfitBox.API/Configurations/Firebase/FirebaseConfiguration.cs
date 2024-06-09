using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace SWD392.OutfitBox.API.Configurations.Firebase
{
    public static class FirebaseConfiguration
    {
        public static void AddFirebaseClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig
            {
                ApiKey = $"{configuration["firebase:api-key"]}",
                AuthDomain = $"{configuration["firebase:project-name"]}.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                 new EmailProvider(),
                 new GoogleProvider()
                 }
            }));
            
        }
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
    }
}
