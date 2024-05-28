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
        Task BenginTransaction();
        Task CommitTransaction();
        Task RollbackTransaction();
        Task<IProductRepository> GetProductRepository();
        Task<IImageRepository> GetImageRepository();
        Task<ICustomerRepository> GetCustomerRepository();
        Task<IBrandRepository> GetBrandRepository();
        Task<IItemsInUserPackageRepository> GetItemsInUserPackageRepository();
        Task<IAreaRepository> GetAreaRepository();
        IPartnerRepository GetPartnerRepository();
    }
}
