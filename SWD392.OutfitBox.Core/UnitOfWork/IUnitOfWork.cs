using SWD392.OutfitBox.Core.RepoInterfaces;
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

        public Task<ICustomerRepository> GetCustomerRepository();

    }
}
