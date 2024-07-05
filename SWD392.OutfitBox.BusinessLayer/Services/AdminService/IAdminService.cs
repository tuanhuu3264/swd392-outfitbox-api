using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.AdminService
{
    public interface IAdminService
    {
        public Task<AdminModel> GetDailyRevenue();
        public Task<AdminModel> GetDailyOrders();
        public Task<AdminModel> GetNewCustomers();
    }
}
