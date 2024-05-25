using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        public Task BenginTransaction();
        public Task CommitTransaction();
        public Task RollbackTransaction();
        public Task<IProductRepository> GetProductRepository();
        public Task<IImageRepository> GetImageRepository();
        public Task<ICustomerRepository> GetCustomerRepository();
        public Task<IBrandRepository> GetBrandRepository();
    }
}
