using AutoMapper;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Area;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Category;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.CategoryPackage;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Customer;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.ItemInUserPackage;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Package;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Partner;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Product;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.ProductReturnOrder;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.ReturnOrder;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Review;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Role;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Wallet;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Area;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Brand;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Category;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.CategoryPackage;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Customer;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.FavouriteProduct;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Package;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Partner;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Product;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.ProductReturnOrder;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.ReturnOrder;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Review;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Role;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Transaction;
using SWD392.OutfitBox.Core.Models.Responses.Package;
using SWD392.OutfitBox.Core.Models.Responses.Wallet;
using SWD392.OutfitBox.DataLayer.Entities;

namespace SWD392.OutfitBox.API.Configurations.Mapper
{
    public class MapperConfigurations :Profile
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


        }
        public void CategoryProfile()
        {
            CreateMap<CreateCategoryRequestDTO, Category>().ReverseMap();
            CreateMap<UpdateCategoryRequestDTO, Category>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryResponseDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryResponseDTO>().ReverseMap();
        }
        public void PackagePofile()
        {
            CreateMap<CreatePackageRequestDTO,Package>().ReverseMap();
            CreateMap<UpdatePackageRequestDTO,Package>().ReverseMap();
            CreateMap<Package, CreatePackageResponseDTO>().ReverseMap();
            CreateMap<Package, UpdatePackageResponseDTO>().ReverseMap();
            CreateMap<Package, PackageDTO>().ReverseMap();
            
        }
        public void CategoryPackageProfile()
        {
            CreateMap<CategoryPackageDTO, CategoryPackage>().ReverseMap();
            CreateMap<CreateCategoryPackageRequestDTO,CategoryPackage>().ReverseMap();
            CreateMap<CreateCategoryPackageResponseDTO,CategoryPackage>().ReverseMap();
            CreateMap<UpdateCategoryPackageRequestDTO,  CategoryPackage>().ReverseMap();    
            CreateMap<UpdateCategoryPackageResponseDTO,CategoryPackage>().ReverseMap(); 
        }
        public void TransactionProfile()
        {
            CreateMap<Transaction,TransactionDTO>().ReverseMap();   
        }
        public void WalletProfile()
        {
            CreateMap<CreateWalletRequestDTO, Wallet>().ReverseMap();
            CreateMap<UpdateWalletRequestDTO, Wallet>().ReverseMap();
            CreateMap<Wallet, CreateWalletResponseDTO>().ReverseMap();
            CreateMap<Wallet, UpdateWalletResponseDTO>().ReverseMap();
            CreateMap<Wallet, WalletDTO>().ReverseMap();
        }
        public void CustomerProfile()
        {
            CreateMap<CreateCustomerRequestDTO, Customer>().ReverseMap();
            CreateMap<UpdateCustomerRequestDTO, Customer>().ReverseMap();
            CreateMap<Customer, CreateCustomerResponseDTO>().ReverseMap();
            CreateMap<Customer, UpdateCustomerResponseDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
        public void RoleProfile()
        {
            CreateMap<CreateRoleRequestDTO,Role>().ReverseMap();
            CreateMap<Role,CreateRoleResponseDTO>().ReverseMap();  
            CreateMap<Role,RoleDTO>().ReverseMap(); 
        }

        public void ReviewProfile()
        {
            CreateMap<CreateReviewRequestDTO, Review>().ForMember(x=>x.ReviewImages, opt=>opt.MapFrom(src=>src.ReviewImages.Select(y=> new ReviewImage()
            {
                Url=y
            })));
            CreateMap<Review, CreateReviewResponseDTO>()
            .ForMember(x => x.ReviewImages, opt => opt.MapFrom(src => src.ReviewImages != null ? src.ReviewImages.Select(x => x.Url) : new List<string>() ));

            CreateMap<Review, ReviewDTO>()
            .ForMember(x => x.ReviewImages, opt => opt.MapFrom(src => src.ReviewImages != null ? src.ReviewImages.Select(x => x.Url) : new List<string>()));
        }
        public void FavouriteProductProfile()
        {
            CreateMap<FavouriteProduct, CreateFavouriteProductResponseDTO>();
        }
        public void ProductProfile()
        {
            CreateMap<Product, CreatedProductDto>().ForMember(x=>x.ImageUrls, pro => pro.MapFrom(x=>x.Images)).ReverseMap();
            CreateMap<string, Image>().ForMember(x => x.Link, img => img.MapFrom(x => x));
            CreateMap<Product, ProductDetailDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(x=> x.Images,pro=>pro.MapFrom(x=>x.Images))
                .ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Image,ImageDto>().ReverseMap();
            CreateMap<Product, ProductGeneral>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.ImgUrl, opt => opt.MapFrom(src => src.Images != null && src.Images.Any() ? src.Images.First().Link : string.Empty))
                .ReverseMap();
            CreateMap<Product, UpdateProductDto>().
                ForMember(x => x.Images, pro => pro.MapFrom(x => x.Images)).
                ReverseMap();
            CreateMap<string, Image>()
                .ForMember(x => x.Link, pro => pro.MapFrom(x => x));
                
        }
        public void ItemInUserPackageProfile()
        {
            CreateMap<ItemInUserPackageDto, ItemInUserPackage>();
        }
        public void ProductReturnOrderProfile()
        {
            CreateMap<ProductReturnOrder,CreateProductReturnOrderRequestDTO>().ReverseMap();
            CreateMap<ProductReturnOrder, CreateProductOrderResponseDTO>().ReverseMap();
            CreateMap<ProductReturnOrder, ProductReturnOrderDTO>().ReverseMap();
        }
        public void ReturnOrderProfile()
        {
            CreateMap<CreateReturnOrderRequestDTO, ReturnOrder>().ReverseMap();
            CreateMap<ReturnOrder,CreateReturnOrderResponseDTO>().ReverseMap();
            CreateMap<ReturnOrderDTO, ReturnOrder>().ReverseMap();  
        }
        public void PartnerProfile()
        {
            CreateMap<Partner,PartnerDTO>().ReverseMap();
            CreateMap<CreatePartnerRequestDTO,Partner>().ReverseMap();
            CreateMap<Partner, CreatePartnerResponseDTO>().ReverseMap();
            CreateMap<UpdatePartnerRequestDTO, Partner>().ReverseMap();
            CreateMap<Partner, UpdatePartnerResponseDTO>().ReverseMap();
        }
        public void AreaProfile()
        {
            CreateMap<Area, AreaDTO>().ReverseMap();
            CreateMap<CreateAreaRequestDTO, Area>().ReverseMap();
            CreateMap<Area, CreateAreaResponseDTO>().ReverseMap();
            CreateMap<UpdateAreaRequestDTO, Area>().ReverseMap();
            CreateMap<Area, UpdateAreaResponseDTO>().ReverseMap();
        }
        public void BrandProfile()
        {
            CreateMap<BrandDTO, Brand>().ReverseMap();
        }
    }
}
