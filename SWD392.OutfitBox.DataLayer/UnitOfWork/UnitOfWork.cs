using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.UnitOfWork
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
        private ICustomerPackageRepository _customerPackageRepository;
        public UnitOfWork(Context dbContext, ICustomerRepository customerRepository, IProductRepository productRepository,
            IBrandRepository brandRepository, ICategoryRepository categoryRepository, IItemsInUserPackageRepository itemsInUserPackageRepository,
            IAreaRepository areaRepository, IPartnerRepository partnerRepository, ICustomerPackageRepository customerPackageRepository)
        {
            _dbContext = dbContext;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _itemsInUserPackageRepository = itemsInUserPackageRepository;
            _areaRepository = areaRepository;
            _partnerRepository = partnerRepository;
            _customerPackageRepository = customerPackageRepository;
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
        public ICustomerPackageRepository GetCustomerPackageRepository() => _customerPackageRepository;
    }
}
