using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Repositories;

namespace SWD392.OutfitBox.DataLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context _dbContext { get; set; }
        public ICustomerRepository _customerRepository { get; set; }

        public IProductRepository _productRepository { get; set; }
        public IImageRepository _imageRepository{ get; set; }
        public IBrandRepository _brandRepository{ get; set; }
        public ICategoryRepository _categoryRepository{ get; set; }
        public IItemsInUserPackageRepository _itemsInUserPackageRepository{ get; set; }
        public ICategoryPackageRepository _categoryPackageRepository { get; set; }
        public IAreaRepository _areaRepository{ get; set; }
        public IPartnerRepository _partnerRepository{ get; set; }
        public ICustomerPackageRepository _customerPackageRepository{ get; set; }
        public IReturnOrderRepository _returnOrderRepository { get; set; }
        public UnitOfWork(Context dbContext, ICustomerRepository customerRepository, IProductRepository productRepository, IImageRepository imageRepository, IBrandRepository brandRepository, ICategoryPackageRepository categoryPackageRepository
                          , ICategoryRepository categoryRepository, IItemsInUserPackageRepository itemsInUserPackageRepository, IAreaRepository areaRepository, IPartnerRepository partnerRepository, ICustomerPackageRepository customerPackageRepository, IReturnOrderRepository returnOrderRepository)
        {
            _dbContext= dbContext;
            _customerRepository= customerRepository;
            _productRepository= productRepository;
            _imageRepository= imageRepository;
            _brandRepository= brandRepository;
            _categoryRepository= categoryRepository;
            _customerPackageRepository= customerPackageRepository;
            _returnOrderRepository= returnOrderRepository;
            _categoryPackageRepository= categoryPackageRepository;
            _partnerRepository= partnerRepository;
            _customerPackageRepository = customerPackageRepository;
            _returnOrderRepository= returnOrderRepository;
            _areaRepository=areaRepository;
            _itemsInUserPackageRepository= itemsInUserPackageRepository;
        }

        public async Task BenginTransaction()
        {
            await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaction()
        {
            await _dbContext.Database.CommitTransactionAsync();
        }

        public async Task RollbackTransaction()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this._dbContext.SaveChangesAsync();
        }


       
      
    }
}
