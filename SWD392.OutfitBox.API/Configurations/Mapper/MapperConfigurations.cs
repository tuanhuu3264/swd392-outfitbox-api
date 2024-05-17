using AutoMapper;
using SWD392.OutfitBox.Core.Models.Requests.Category;
using SWD392.OutfitBox.Core.Models.Requests.Package;
using SWD392.OutfitBox.Core.Models.Requests.Product;
using SWD392.OutfitBox.Core.Models.Requests.User;
using SWD392.OutfitBox.Core.Models.Requests.Wallet;
using SWD392.OutfitBox.Core.Models.Responses.Category;
using SWD392.OutfitBox.Core.Models.Responses.Package;
using SWD392.OutfitBox.Core.Models.Responses.Transaction;
using SWD392.OutfitBox.Core.Models.Responses.User;
using SWD392.OutfitBox.Core.Models.Responses.Wallet;
using SWD392.OutfitBox.Domain.Entities;

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
            UserProfile();
            ProductProfile();
        
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
        public void UserProfile()
        {
            CreateMap<CreateUserRequestDTO, User>().ReverseMap();
            CreateMap<UpdateUserRequestDTO, User>().ReverseMap();
            CreateMap<User, Core.Models.Responses.User.CreateUserResponseDTO>().ReverseMap();
            CreateMap<User, Core.Models.Responses.User.UpdateUserResponseDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
        public void ProductProfile()
        {
            CreateMap<Product,CreatedProductDto>().ReverseMap();
        }
    }
}
