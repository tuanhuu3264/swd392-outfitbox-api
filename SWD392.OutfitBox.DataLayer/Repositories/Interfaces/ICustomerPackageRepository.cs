using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Repositories.Interfaces
{
    public interface ICustomerPackageRepository
    {
        Task<CustomerPackage> CreateUserPackage(CustomerPackage userPackage);
        Task<CustomerPackage> GetCustomerPackageById(int id);
        Task<CustomerPackage> SaveAsyn(CustomerPackage customerPacket);
        Task<CustomerPackage> GetCustomerPackgageAndItemsbyId(int id);
        Task<List<AdminData>> GetTotalPackagePrice();
        Task<List<AdminData>> GetDailyOrders();
    }
}
