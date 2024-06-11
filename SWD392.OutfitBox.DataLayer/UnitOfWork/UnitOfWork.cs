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
using SWD392.OutfitBox.DataLayer.Repositories.Interfaces;

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
        public IAreaRepository _areaRepository{ get; set; }
        public IPartnerRepository _partnerRepository{ get; set; }
        public ICustomerPackageRepository _customerPackageRepository{ get; set; }
        public IReturnOrderRepository _returnOrderRepository { get; set; }
        public IDepositRepository _depositRepository { get; set; }
        public IWalletRepository _walletRepository { get; set; }
        public ITransactionRepository _transactionRepository { get; set; }
        public UnitOfWork(Context dbContext)
        {
            _dbContext = dbContext;
            _customerRepository = new CustomerRepository(_dbContext);
            _productRepository = new ProductRepository(_dbContext);
            _brandRepository = new BrandRepository(_dbContext);
            _categoryRepository = new CategoryRepository(_dbContext);
            _itemsInUserPackageRepository = new ItemInUserPackageRepository(_dbContext);
            _areaRepository = new AreaRepository(_dbContext);
            _partnerRepository = new PartnerRepository(_dbContext);
            _customerPackageRepository = new CustomerPackageRepository(_dbContext);
            _imageRepository = new ImageRepository(_dbContext);
            _returnOrderRepository = new ReturnOrderRepository(_dbContext);
            _walletRepository = new WalletRepository(_dbContext);
            _transactionRepository = new TransactionRepository(_dbContext);
        }

        public async Task BenginTransaction()
        {
            await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaction()
        {
            await _dbContext.Database.CommitTransactionAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task RollbackTransaction()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this._dbContext.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

      
    }
}
