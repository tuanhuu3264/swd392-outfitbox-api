using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD392.OutfitBox.DataLayer.Repositories.Interfaces;

namespace SWD392.OutfitBox.DataLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ICustomerRepository _customerRepository { get; set; }
        public IProductRepository _productRepository { get; set; }
        public IImageRepository _imageRepository { get; set; }
        public IBrandRepository _brandRepository { get; set; }
        public ICategoryRepository _categoryRepository { get; set; }
        public IItemsInUserPackageRepository _itemsInUserPackageRepository { get; set; }
        public IAreaRepository _areaRepository { get; set; }
        public IPartnerRepository _partnerRepository { get; set; }
        public ICustomerPackageRepository _customerPackageRepository { get; set; }
        public IReturnOrderRepository _returnOrderRepository { get; set; }
        public IDepositRepository _depositRepository { get; set; }
        public IWalletRepository _walletRepository { get; set; }
        public ITransactionRepository _transactionRepository { get; set; }
        public IPackageRepository _packageRepository { get; set; }

        public ICategoryPackageRepository _categoryPackageRepository { get; set; }
        Task BenginTransaction();
        Task CommitTransaction();
        Task RollbackTransaction();
        Task<int> SaveChangesAsync();

    }
}
