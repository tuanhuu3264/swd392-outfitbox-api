using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.DataLayer.Databases.Redis;

namespace SWD392.OutfitBox.API.Configurations.Databases
{
    public static class DatabasesConfigurations
    {
        public static void AddSQLServerDatabase(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer("data source=34.123.203.83;initial catalog=Outfit4Rent;user id=sa;password=<YourStrong@Passw0rd>;trustservercertificate=true;multipleactiveresultsets=true;")
                       .EnableSensitiveDataLogging();
            });
        }

        public static void AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(
             opt =>
                   {
                       opt.Configuration = "localhost:6379";
                       opt.InstanceName = "RedisDemo_";

                   });
        }
    }
}
