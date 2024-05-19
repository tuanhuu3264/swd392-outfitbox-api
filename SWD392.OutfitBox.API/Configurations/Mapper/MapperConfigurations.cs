﻿using AutoMapper;
using SWD392.OutfitBox.Core.Models.Requests.Category;
using SWD392.OutfitBox.Core.Models.Requests.Package;
using SWD392.OutfitBox.Core.Models.Requests.Role;
using SWD392.OutfitBox.Core.Models.Requests.Customer;
using SWD392.OutfitBox.Core.Models.Requests.Wallet;
using SWD392.OutfitBox.Core.Models.Responses.Category;
using SWD392.OutfitBox.Core.Models.Responses.Package;
using SWD392.OutfitBox.Core.Models.Responses.Role;
using SWD392.OutfitBox.Core.Models.Responses.Transaction;
using SWD392.OutfitBox.Core.Models.Responses.Customer;
using SWD392.OutfitBox.Core.Models.Responses.Wallet;
using SWD392.OutfitBox.Domain.Entities;
using SWD392.OutfitBox.Core.Models.Requests.CategoryPackage;
using SWD392.OutfitBox.Core.Models.Responses.CategoryPackage;

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
            CreateMap<CreateCategoryResponseDTO,CategoryPackage>().ReverseMap();
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
    }
}
