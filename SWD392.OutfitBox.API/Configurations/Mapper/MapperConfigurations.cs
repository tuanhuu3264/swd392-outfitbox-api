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
using SWD392.OutfitBox.BusinessLayer;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.Entities;

namespace SWD392.OutfitBox.API.Configurations.Mapper
{
    public class MapperConfigurations : Profile
    {
        public MapperConfigurations()
        {   

            
            CategoryProfile();
            PackagePofile();
            TransactionProfile();
            WalletProfile();
            CustomerProfile();
            RoleProfile();
            CategoryPackageProfile();
            ReviewProfile();
            FavouriteProductProfile();
            ProductProfile();
            ProductReturnOrderProfile();
            ReturnOrderProfile();
            PartnerProfile();
            AreaProfile();
            BrandProfile();
            ItemInUserPackageProfile();

        }
        public void CategoryProfile()
        {
            CreateMap<CreateCategoryRequestDTO, CategoryModel>().ReverseMap();
            CreateMap<UpdateCategoryRequestDTO, CategoryModel>().ReverseMap();
            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
        public void PackagePofile()
        {
            CreateMap<CreatePackageRequestDTO, PackageModel>().ReverseMap();
            CreateMap<UpdatePackageRequestDTO, PackageModel>().ReverseMap();
            CreateMap<Package, PackageModel>();
            CreateMap<PackageModel,Package>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
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
            CreateMap<WalletModel,Wallet>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
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
            CreateMap<CreateReviewRequestDTO, ReviewModel>();
            CreateMap<Review, ReviewModel>();
            CreateMap<ReviewModel, Review>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        }
        public void FavouriteProductProfile()
        {
            CreateMap<FavouriteProduct, FavouriteProductModel>();
        }
        public void ProductProfile()
        {
            CreateMap<ProductModel, CreatedProductDto>()
                .ForMember(x=>x.ImageUrls,opt =>opt.MapFrom(x=>x.Images))
                .ReverseMap();
            CreateMap<string, ImageModel>().ForMember(x => x.Link, img => img.MapFrom(x => x));
            CreateMap<Product, ProductModel>()
                .ForMember(x=>x.Images,opt=>opt.MapFrom(x=>x.Images));
            CreateMap<Image, ImageModel>().ReverseMap();
            CreateMap<ProductModel, UpdateProductDto>().ReverseMap();
            CreateMap<string, Image>()
                .ForMember(x => x.Link, pro => pro.MapFrom(x => x));
            CreateMap<ProductModel, Product>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        }
        public void ItemInUserPackageProfile()
        {
           /* CreateMap<ItemInUserPackageDto, ItemInUserPackage>()
                .ForPath(x => x.Product.Name, opt => opt.MapFrom(src => src.ProductName))
                .ReverseMap();
            CreateMap<ItemInUserPackage, CreatedItemInPackage>().ReverseMap();
            CreateMap<UpdateItemInPackage, ItemInUserPackage>().ReverseMap();
            CreateMap<ItemInUserPackage, ItemInUserPackage>();*/
        }
        public void ProductReturnOrderProfile()
        {
            CreateMap<ProductReturnOrderModel, CreateProductReturnOrderRequestDTO>().ReverseMap();
            CreateMap<ProductReturnOrder, ProductReturnOrderModel>();
            CreateMap<ProductReturnOrderModel, ProductReturnOrder>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            ;
        }
        public void ReturnOrderProfile()
        {
            CreateMap<CreateReturnOrderRequestDTO, ReturnOrderModel>().ReverseMap();

            CreateMap<ReturnOrderModel, ReturnOrder>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ReturnOrder, ReturnOrderModel>();
        }
        public void PartnerProfile()
        {
            CreateMap<Partner, PartnerModel>();
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
        {   CreateMap<BrandModel,Brand>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Brand, BrandModel>();
            CreateMap<CreateBrandRequestDTO, BrandModel>().ReverseMap();
            CreateMap<UpdateBrandRequestDTO, BrandModel>().ReverseMap();
        
        }
        
    }
}
