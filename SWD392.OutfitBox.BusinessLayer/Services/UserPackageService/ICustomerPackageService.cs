using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.BusinessModels.PaymentModels;
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
        Task<CustomerPackageModel> CreateCustomerPackage(CustomerPackageModel customerPackageModel);
        Task<CustomerPackageModel> GetPackagebyId( int packageid);
    }
}
