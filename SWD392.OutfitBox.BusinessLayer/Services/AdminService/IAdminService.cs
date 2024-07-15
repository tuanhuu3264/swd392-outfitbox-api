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
        public Task<AdminModel> GetNumberTransaction(string kind);
        public Task<List<AdminOjectModel>> GetTrendingPackage(string kind);
        public  Task<List<AdminOjectModel>> GetQuantityRentigPoduct(string kind);
        public Task<List<AdminOjectModel>> GetQuantityUnReturnedPoduct(string kind);
        public Task<AdminModel> GetCompletedOrder(string kind);
        public Task<AdminModel> GetCanceledOrder(string kind);
        public  Task<AdminModel> GetLostProduct(string kind);
    }
}
