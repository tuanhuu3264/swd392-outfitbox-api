using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Interfaces
{
    public interface ICustomerPackageRepository
    {
        Task<CustomerPackage> CreateUserPackage(CustomerPackage userPackage);
    }
}
