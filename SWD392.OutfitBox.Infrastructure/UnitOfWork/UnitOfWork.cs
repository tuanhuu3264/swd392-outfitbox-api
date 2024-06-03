using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Core.UnitOfWork;
using SWD392.OutfitBox.Domain.Entities;
using SWD392.OutfitBox.Infrastructure.Databases.SQLServer;
using SWD392.OutfitBox.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context _dbContext; 
        private ICustomerRepository _customerRepository;
        private IProductRepository _productRepository;
        private IImageRepository _imageRepository;
        private IBrandRepository _brandRepository;
        private ICategoryRepository _categoryRepository;
        private IItemsInUserPackageRepository _itemsInUserPackageRepository;
        private IAreaRepository _areaRepository;
        private IPartnerRepository _partnerRepository;

        public UnitOfWork(Context dbContext, ICustomerRepository customerRepository, IProductRepository productRepository,
            IBrandRepository brandRepository, ICategoryRepository categoryRepository, IItemsInUserPackageRepository itemsInUserPackageRepository,
            IAreaRepository areaRepository, IPartnerRepository partnerRepository)
        {
            _dbContext = dbContext;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _itemsInUserPackageRepository = itemsInUserPackageRepository;
            _areaRepository = areaRepository;
            _partnerRepository = partnerRepository;
        }

        public async Task BenginTransaction()
        {
            await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaction()
        {
            await _dbContext.Database.CommitTransactionAsync();
        }
        public async Task<ICustomerRepository> GetCustomerRepository()
        {
            return _customerRepository;
        }

        public async Task<IImageRepository> GetImageRepository()
        {
            return _imageRepository;
        }

        public async Task<IProductRepository> GetProductRepository()
        {
            return _productRepository;
        }
        public async Task RollbackTransaction()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }
        public async Task<IBrandRepository> GetBrandRepository()
        {
            return _brandRepository;
        }
        public async Task<ICategoryRepository> GetCategoryRepository()
        {
            return _categoryRepository;
        }
        public async Task<IItemsInUserPackageRepository> GetItemsInUserPackageRepository()
        {
            return _itemsInUserPackageRepository;
        }

        public async Task<IAreaRepository> GetAreaRepository() => _areaRepository;

        public IPartnerRepository GetPartnerRepository() => _partnerRepository;
    }
}
