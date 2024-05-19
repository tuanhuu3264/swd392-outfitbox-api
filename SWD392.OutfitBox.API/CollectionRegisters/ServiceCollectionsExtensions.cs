
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Core.Services.AuthService;
using SWD392.OutfitBox.Core.Services.CategoryPackageService;
using SWD392.OutfitBox.Core.Services.CategoryService;
using SWD392.OutfitBox.Core.Services.PackageService;
using SWD392.OutfitBox.Core.Services.ProductService;
using SWD392.OutfitBox.Core.Services.RoleService;
using SWD392.OutfitBox.Core.Services.TransactionService;
using SWD392.OutfitBox.Core.Services.UserService;
using SWD392.OutfitBox.Core.Services.WalletService;
using SWD392.OutfitBox.Domain;
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
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<ICustomerPackageRepository, CustomerPackageRepository>();    
            services.AddScoped<IItemsInUserPackage, ItemInUserPackageRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ICategoryPackageRepository, CategoryPackageRepository>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPackageService, PackageService>();  
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IWalletService,WalletService>(); 
            services.AddScoped<IRoleService,RoleService>();
            services.AddScoped<ICategoryPackageService,CategoryPackageService>();
        }

    }
}
