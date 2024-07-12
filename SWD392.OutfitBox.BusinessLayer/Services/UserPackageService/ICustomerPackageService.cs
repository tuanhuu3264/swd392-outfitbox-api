using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.BusinessModels.PaymentModels;
using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SWD392.OutfitBox.BusinessLayer.Services.UserPackageService
{
    public interface ICustomerPackageService
    {
        Task<CustomerPackageModel> ChangeStatus(int id, int status);
        Task<CustomerPackageModel> CreateCustomerPackage(CustomerPackageModel customerPackageModel, int walletId);
        Task<CustomerPackageModel> GetPackagebyId( int packageid);
        Task<List<CustomerPackageModel>> GetAllCustomerPackageByCustomerId(int customerId);
        Task<List<CustomerPackageModel>> GetCustomrPackagesByStatus(int status);
         Task<List<CustomerPackageModel>> GetListOrder(
    int? start = null,
    int? end = null,
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
