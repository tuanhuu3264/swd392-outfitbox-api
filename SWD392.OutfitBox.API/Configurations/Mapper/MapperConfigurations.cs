using Abp.Extensions;
using AutoMapper;
using SWD392.OutfitBox.API.DTOs.Area;
using SWD392.OutfitBox.API.DTOs.Brand;
using SWD392.OutfitBox.API.DTOs.Category;
using SWD392.OutfitBox.API.DTOs.CategoryPackage;
using SWD392.OutfitBox.API.DTOs.CreatePackage;
using SWD392.OutfitBox.API.DTOs.Customer;
using SWD392.OutfitBox.API.DTOs.Package;
using SWD392.OutfitBox.API.DTOs.Partner;
using SWD392.OutfitBox.API.DTOs.Product;
using SWD392.OutfitBox.API.DTOs.ProductReturnOrder;
using SWD392.OutfitBox.API.DTOs.ReturnOrder;
using SWD392.OutfitBox.API.DTOs.Review;
using SWD392.OutfitBox.API.DTOs.Role;
using SWD392.OutfitBox.API.DTOs.Wallet;
using SWD392.OutfitBox.API.RequestModels.CustomerPackage;
using SWD392.OutfitBox.BusinessLayer;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.BusinessModels.PaymentModels;
using SWD392.OutfitBox.DataLayer.Entities;
using static System.Net.WebRequestMethods;

namespace SWD392.OutfitBox.API.Configurations.Mapper
{
    public class MapperConfigurations : Profile
    {
        public MapperConfigurations()
        {


            CategoryProfile();
          
            TransactionProfile();
            WalletProfile();
            CustomerProfile();
            RoleProfile();
            CategoryPackageProfile();
            PackageProfile();
            ReviewProfile();
            FavouriteProductProfile();
            ProductProfile();
            ProductReturnOrderProfile();
            ReturnOrderProfile();
            PartnerProfile();
            AreaProfile();
            BrandProfile();
            ItemInUserPackageProfile();
            CustomerPackageProfile();

        }
        public void CategoryProfile()
        {
            CreateMap<CreateCategoryRequestDTO, CategoryModel>().ReverseMap();
            CreateMap<UpdateCategoryRequestDTO, CategoryModel>().ReverseMap();
            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
        public void PackageProfile()
        {
            CreateMap<CreatePackageRequestDTO, PackageModel>().ReverseMap();
            CreateMap<UpdatePackageRequestDTO, PackageModel>().ReverseMap();
            CreateMap<Package, PackageModel>();
            CreateMap<Package, PackageModel>();
            CreateMap<CategoryPackageDTO, CategoryPackageModel>();
            CreateMap<PackageModel, Package>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
        public void CategoryPackageProfile()
        {
            CreateMap<CategoryPackageModel, CategoryPackage>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<CategoryPackage, CategoryPackageModel>();
            CreateMap<CreateCategoryPackageRequestDTO, CategoryPackageModel>().ReverseMap();

            CreateMap<UpdateCategoryPackageRequestDTO, CategoryPackageModel>().ReverseMap();
        }
        public void TransactionProfile()
        {
            CreateMap<Transaction, BusinessLayer.BusinessModels.TransactionModel>().ReverseMap();
        }
        public void WalletProfile()
        {
            CreateMap<CreateWalletRequestDTO, WalletModel>().ReverseMap();
            CreateMap<UpdateWalletRequestDTO, WalletModel>().ReverseMap();
            CreateMap<Wallet, WalletModel>().ReverseMap();
            CreateMap<WalletModel, Wallet>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
        public void CustomerProfile()
        {
            CreateMap<CreateCustomerRequestDTO, CustomerModel>().ReverseMap();
            CreateMap<UpdateCustomerRequestDTO, CustomerModel>().ReverseMap();

            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<CustomerModel, Customer>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
        public void RoleProfile()
        {
            CreateMap<CreateRoleRequestDTO, RoleModel>().ReverseMap();
            CreateMap<Role, RoleModel>();
            CreateMap<RoleModel, Role>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }

        public void ReviewProfile()
        {
            CreateMap<CreateReviewRequestDTO, ReviewModel>().ForMember(x=>x.Images, otp => otp.MapFrom(x => x.ReviewImages));
            CreateMap<ReviewImageModel,ImageRequestModel>().ForMember(otp=>otp.Url,x=>x.MapFrom(y=>y.Url)).ReverseMap();
            CreateMap<Review, ReviewModel>().ForMember(x => x.Images, otp => otp.MapFrom(x => x.ReviewImages))
                .ForPath(x => x.CustomerName, otp => otp.MapFrom(x => x.User.Name))
                .ForPath(x => x.CustomerAvatar, otp => otp.MapFrom(x => x.User.Picture));
            CreateMap<ReviewModel, Review>().ForMember(x => x.ReviewImages, otp => otp.MapFrom(x => x.Images));
            CreateMap<ReviewImage, ReviewImageModel>().ReverseMap();
            //CreateMap<ReviewModel, Review>().ForMember(x=>x.ReviewImages,otp=>otp.MapFrom(x=>x.Images)).ReverseMap();

        }
        public void FavouriteProductProfile()
        {
            CreateMap<FavouriteProduct, FavouriteProductModel>();
        }
        public void ProductProfile()
        {
            CreateMap<ImageRequestModel, ImageModel>().ForMember(x=>x.Link, opt=>opt.MapFrom(y=>y.Url));
            CreateMap<CreatedProductDto, ProductModel>().ForMember(x => x.Images, opt => opt.MapFrom(x => x.Images));
            CreateMap<UpdateProductDto, ProductModel>().ForMember(x => x.Images, opt => opt.MapFrom(x => x.Images));
            CreateMap<ProductModel, Product>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Product, ProductModel>();
            CreateMap<ImageModel, Image>().ReverseMap();
        }
        public void ItemInUserPackageProfile()
        {
            //CreateMap<ItemInUserPackageDto, ItemInUserPackage>()
            //    .ForPath(x => x.Product.Name, opt => opt.MapFrom(src => src.ProductName))
            //    .ReverseMap();ll
            //CreateMap<ItemInUserPackage, CreatedItemInPackage>().ReverseMap();
            //CreateMap<UpdateItemInPackage, ItemInUserPackage>().ReverseMap();
            CreateMap<ItemInUserPackage, ItemInUserPackageModel>().ReverseMap();
        }
        public void ProductReturnOrderProfile()
        {
            CreateMap<ProductReturnOrderModel, CreateProductReturnOrderRequestDTO>().ReverseMap();
            CreateMap<ProductReturnOrder, ProductReturnOrderModel>();
            CreateMap<ProductReturnOrder, ProductInReturnOrderViewModel>().ForMember(x=>x.Product, opt=>opt.MapFrom(y=>y.Product));
            CreateMap<ProductReturnOrderModel, ProductReturnOrder>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            ;
        }
        public void ReturnOrderProfile()
        {
            CreateMap<CreateReturnOrderRequestDTO, ReturnOrderModel>().ForMember(x=>x.ProductReturnOrders, opt=>opt.MapFrom(x=>x.ProductReturnOrders)).ReverseMap();

            CreateMap<ReturnOrderModel, ReturnOrder>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ReturnOrder, ReturnOrderModel>().ForMember(x=>x.ProductReturnOrders, opt=>opt.MapFrom(x=>x.ProductReturnOrders));
        }
        public void PartnerProfile()
        {
            CreateMap<Partner, PartnerModel>().ForPath(x=>x.Coordinate.X, x=>x.MapFrom(x=>x.X)).ForPath(x => x.Coordinate.Y, x => x.MapFrom(x => x.Y));
            CreateMap<CreatePartnerRequestDTO, PartnerModel>().ReverseMap();
            CreateMap<UpdatePartnerRequestDTO, PartnerModel>().ReverseMap();
            CreateMap<PartnerModel, Partner>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        }
        public void AreaProfile()
        {

            CreateMap<AreaModel, Area>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Area, AreaModel>();
            CreateMap<CreateAreaRequestDTO, AreaModel>().ReverseMap();
            CreateMap<UpdateAreaRequestDTO, AreaModel>().ReverseMap();


        }
        public void BrandProfile()
        {
            CreateMap<BrandModel, Brand>().ForMember(x => x.Status, opt => opt.Condition(t => t.Status.HasValue))
                 .ForMember(x => x.IsFeatured, opt => opt.Condition(t => t.IsFeatured.HasValue)).ForAllMembers(opts =>
            {
                opts.AllowNull();
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });


            CreateMap<Brand, BrandModel>();
            CreateMap<CreateBrandRequestDTO, BrandModel>().ReverseMap();
            CreateMap<UpdateBrandRequestDTO, BrandModel>().ReverseMap();
        }
        public void CustomerPackageProfile()
        {
            CreateMap<CustomerPackageModel, CustomerPackage>()
                .ForMember(x=>x.Items,opt =>opt.MapFrom(x=>x.ItemInUsers))
                .ReverseMap();
            CreateMap<ItemInUserPackage, ItemInUserPackageModel>().ReverseMap();
            CreateMap<CustomerPackageRequest,CustomerPackageModel>()
                .ForMember(x=>x.ItemInUsers,x=>x.MapFrom(x=>x.CreateItems)).ReverseMap();
            CreateMap<CreateItemInUserPackage, ItemInUserPackageModel>().ReverseMap();
        }
        public bool IsNonDefaultValue<T>(T value)
        {
            if (value == null)
            {
                return false;
            }

            return !EqualityComparer<T>.Default.Equals(value, default(T));
        }
    }
}
