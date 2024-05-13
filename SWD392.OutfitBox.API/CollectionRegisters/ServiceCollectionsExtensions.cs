using FAMS.Api.Repositories;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Core.Services.ProductService;
using SWD392.OutfitBox.Domain;
using SWD392.OutfitBox.Infrastructure.Repositories;
using System.Text.Json.Serialization;

namespace SWD392.OutfitBox.API.CollectionRegisters
{
    public static class ServiceCollectionsExtensions
    {
        public  static  void RegisterService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IProductService, ProductService>();
        }

    }
}
