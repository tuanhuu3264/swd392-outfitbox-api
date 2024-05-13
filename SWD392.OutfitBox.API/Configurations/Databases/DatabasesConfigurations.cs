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
                options.UseSqlServer("server=localhost;database=OutfitBox;uid=sa;pwd=12345;TrustServerCertificate=True;MultipleActiveResultSets=True")
                       .EnableSensitiveDataLogging();
            });
        }

        public static void AddRedis(this IServiceCollection services, IConfiguration configuration)
        {

        }
    }
}
