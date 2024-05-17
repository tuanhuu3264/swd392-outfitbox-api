using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.Infrastructure.Databases.SQLServer;

namespace SWD392.OutfitBox.API.Configurations.Databases
{
    public static class DatabasesConfigurations
    {
        public static void AddSQLServerDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer("data source=34.70.224.243;initial catalog=Outfit4Rent;user id=sa;password=<YourStrong@Passw0rd>;trustservercertificate=true;multipleactiveresultsets=true;")
                       .EnableSensitiveDataLogging();
            });
        }

        public static void AddRedis(this IServiceCollection services, IConfiguration configuration)
        {

        }
    }
}
