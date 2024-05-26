
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Core.Services.AuthService;
using SWD392.OutfitBox.Core.Services.CategoryPackageService;
using SWD392.OutfitBox.Core.Services.CategoryService;
using SWD392.OutfitBox.Core.Services.FavouriteProduct;
using SWD392.OutfitBox.Core.Services.ItemInUserPackage;
using SWD392.OutfitBox.Core.Services.PackageService;
using SWD392.OutfitBox.Core.Services.ProductService;
using SWD392.OutfitBox.Core.Services.ReviewService;
using SWD392.OutfitBox.Core.Services.RoleService;
using SWD392.OutfitBox.Core.Services.TransactionService;
using SWD392.OutfitBox.Core.Services.UserService;
using SWD392.OutfitBox.Core.Services.WalletService;
using SWD392.OutfitBox.Core.UnitOfWork;
using SWD392.OutfitBox.Domain;
using SWD392.OutfitBox.Infrastructure.Repositories;
using SWD392.OutfitBox.Infrastructure.UnitOfWork;
using System.Text.Json.Serialization;

namespace SWD392.OutfitBox.API.CollectionRegisters
{
    public static class ServiceCollectionsExtensions
    {
        public  static  void RegisterService(this IServiceCollection services)
        {

            services.RepositoriesRegister();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.ServiesRegister();
            services.AddScoped<IUnitOfWork,UnitOfWork>();   
        }
        public static void ServiesRegister(this IServiceCollection services)
        {
        
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPackageService, PackageService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICategoryPackageService, CategoryPackageService>();
            services.AddScoped<IReviewService, ReviewService>();  
            services.AddScoped<IFavouriteProductService, FavouriteProductService>();
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<IItemsInUserPackageService, ItemsInUserPackageService>();
        }
        public static void RepositoriesRegister(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<ICustomerPackageRepository, CustomerPackageRepository>();
            services.AddScoped<IItemsInUserPackageRepository, ItemInUserPackageRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ICategoryPackageRepository, CategoryPackageRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();  
            services.AddScoped<IReviewImageRepository, ReviewImageRepository>();
            services.AddScoped<IFavouriteProductRepository, FavouriteProductRepository>();
            services.AddScoped<IWalletService,WalletService>(); 
            services.AddScoped<IRoleService,RoleService>();
            services.AddScoped<ICategoryPackageService,CategoryPackageService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
        }

    }
}
