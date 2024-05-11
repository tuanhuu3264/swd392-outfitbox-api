using Microsoft.EntityFrameworkCore;

namespace SWD392.OutfitBox.API.Configurations.Databases
{
    public static class DatabasesConfigurations
    {
        public static void AddSQLServerDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"])
                       .EnableSensitiveDataLogging();
            });
        }

        public static void AddRedis(this IServiceCollection services, IConfiguration configuration)
        {

        }
    }
}
