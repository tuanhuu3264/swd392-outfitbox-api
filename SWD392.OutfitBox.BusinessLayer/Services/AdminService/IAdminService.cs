using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.BusinessModels.AdminModel;
using SWD392.OutfitBox.DataLayer.Entities;
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
        public Task<AdminModel> GetNumberTransaction();
        public Task<List<AdminObjectData>> GetTrendingPackage();
        public  Task<List<AdminObjectData>> GetQuantityRentingProduct();
        public Task<List<AdminObjectData>> GetQuantityUnReturnedProduct();
        public Task<AdminModel> GetCompletedOrder();
        public Task<AdminModel> GetCanceledOrder();
        public Task<List<AdminObjectData>> GetLostProduct();
    }
}
