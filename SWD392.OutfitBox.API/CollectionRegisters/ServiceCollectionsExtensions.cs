
using BusinessLayer.Services;
using SWD392.OutfitBox.BusinessLayer.Services.AuthService;
using SWD392.OutfitBox.BusinessLayer.Services.CategoryPackageService;
using SWD392.OutfitBox.BusinessLayer.Services.CategoryService;
using SWD392.OutfitBox.BusinessLayer.Services.FirebaseService;
using SWD392.OutfitBox.BusinessLayer.Services.FavouriteProduct;
using SWD392.OutfitBox.BusinessLayer.Services.ItemInUserPackageService;
using SWD392.OutfitBox.BusinessLayer.Services.PackageService;
using SWD392.OutfitBox.BusinessLayer.Services.ProductService;
using SWD392.OutfitBox.BusinessLayer.Services.ReviewService;
using SWD392.OutfitBox.BusinessLayer.Services.RoleService;
using SWD392.OutfitBox.BusinessLayer.Services.TransactionService;
using SWD392.OutfitBox.BusinessLayer.Services.UserService;
using SWD392.OutfitBox.BusinessLayer.Services.WalletService;
using SWD392.OutfitBox.DataLayer.Interfaces;
using SWD392.OutfitBox.DataLayer.Repositories;
using SWD392.OutfitBox.DataLayer.UnitOfWork;
using System.Text.Json.Serialization;
using IPaymentService = BusinessLayer.Services.IPaymentService;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.BusinessLayer.Services.AreaService;
using SWD392.OutfitBox.BusinessLayer.Services.PartnerService;
using SWD392.OutfitBox.BusinessLayer.Services.ReturnOrderService;

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
            services.AddScoped<IFirebaseService, FirebaseService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IFirebaseService, FirebaseService>();
            services.AddScoped<IAreaService, AreaService>();    
            services.AddScoped<IPartnerService, PartnerService>();  
            services.AddScoped<IReturnOrderService, ReturnOrderService>();
            services.AddScoped <IProductReturnOrderRepository, ProductReturnOrderRepository>(); 
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
            services.AddScoped<IPartnerRepository,PartnerRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();  
            services.AddScoped<IProductReturnOrderRepository, ProductReturnOrderRepository>();
            services.AddScoped<IReturnOrderRepository, ReturnOrderRepository>();
        }

    }
}
