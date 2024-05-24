using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Core.UnitOfWork;
using SWD392.OutfitBox.Infrastructure.Databases.SQLServer;
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
        public UnitOfWork(Context dbContext, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _dbContext = dbContext;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
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

        public async Task<IProductRepository> GetProductRepository()
        {
            return _productRepository;
        }


        public async Task RollbackTransaction()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }
    }
}
