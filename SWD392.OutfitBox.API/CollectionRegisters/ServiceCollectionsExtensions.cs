
using Microsoft.Identity.Client;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Core.Services.CategoryService;
using SWD392.OutfitBox.Core.Services.PackageService;
using SWD392.OutfitBox.Core.Services.ProductService;
using SWD392.OutfitBox.Core.Services.TransactionService;
using SWD392.OutfitBox.Core.Services.UserService;
using SWD392.OutfitBox.Core.Services.WalletService;
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
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IUserPackageRepository, UserPackageRepository>();    
            services.AddScoped<IItemsInUserPackage, ItemInUserPackageRepository>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPackageService, PackageService>();  
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWalletService,WalletService>(); 
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ITypeRepository, TypeRepository>();
        }

    }
}
