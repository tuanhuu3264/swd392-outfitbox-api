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
        Task<List<CustomerPackage>> GetCustomerPackageByCustomerId(int customerId);
        Task<List<CustomerPackage>> GetCustomerPackageByStatus(int status);
        public Task<List<CustomerPackage>> GetListOrder(
    int? pageIndex = null,
    int? pageSize = null,
    string sorted = "",
    string orders = "",
    string packageName = "",
    int? customerId = null,
    int? packageId = null,
    int? status = null,
    DateTime? dateFrom = null,
    DateTime? dateTo = null,
    string receiverName = "",
    string receiverPhone = "",
    string receiverAddress = "",
    double? maxPrice = null,
    double? minPrice = null,
    int? transactionId = null,
    int? quantityOfItems = null,
    double? maxTotalDeposit = null,
    double? minTotalDeposit = null);
    }
}
