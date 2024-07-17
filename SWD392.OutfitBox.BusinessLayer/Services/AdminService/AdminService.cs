using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.BusinessModels.AdminModel;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Protobuf.WellKnownTypes.Field.Types;

namespace SWD392.OutfitBox.BusinessLayer.Services.AdminService
{
    public class AdminService : IAdminService
    {
        protected IUnitOfWork _unitOfWork;
        public AdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AdminModel> GetDailyOrders()
        {
            var data = await _unitOfWork._customerPackageRepository.GetDailyOrders();
            double sum = 0;
            var result = new AdminModel();
            result.Data = new List<AdminData>();
            if (data != null && data.Count > 1)
            {
                for (var i = DateTime.Now.Date; i >= data.Min(x => x.Date).Date;i=i.AddDays(-1))
                {
                    var test = data.Min(x => x.Date).Date;
                    if (data.Any(x => x.Date.Date != i))
                    {
                        data.Add(new AdminData { Date = i, Value = 0 });
                    }
                }
                data = data.OrderBy(c => c.Date).ToList();
                var lastCustomer = data[^1];
                var penultimateCustomer = data[^2];
                var trend = lastCustomer.Value - penultimateCustomer.Value;
                if (penultimateCustomer.Value == 0)
                {
                result.Trend = 0;
                }
                else
                result.Trend = trend / penultimateCustomer.Value * 100;
            }
            foreach (var customer in data)
            {
                result.Data.Add(customer);
                sum += customer.Value;
            }
            return result;

        }

        public async Task<AdminModel> GetDailyRevenue()
        {
            var data = await _unitOfWork._customerPackageRepository.GetTotalPackagePrice();
            double sum = 0;
            var result = new AdminModel();
            result.Data = new List<AdminData>();
            if (data != null && data.Count > 1)
            {
                data = data.OrderBy(c => c.Date).ToList();
                var lastCustomer = data[^1];
                var penultimateCustomer = data[^2];
                var trend = lastCustomer.Value - penultimateCustomer.Value;
                if (penultimateCustomer.Value == 0)
                {
                    result.Trend = 0;
                }
                else
                    result.Trend = trend / penultimateCustomer.Value * 100;
            }
            foreach (var customer in data)
            {
                result.Data.Add(customer);
                sum = sum + customer.Value;
            }
            result.Total = sum;
            return result;
        }

        public async Task<AdminModel> GetNewCustomers()
        {
            var data = await _unitOfWork._customerRepository.GetNewCustomers();
            double sum = 0;
            var result = new AdminModel();
            result.Data = new List<AdminData>();
            if (data != null && data.Count > 1)
            {
                data = data.OrderBy(c => c.Date).ToList();
                var lastCustomer = data[^1];
                var penultimateCustomer = data[^2];
                var trend = lastCustomer.Value - penultimateCustomer.Value;
                if (penultimateCustomer.Value == 0)
                {
                    result.Trend = 0;
                }
                else
                    result.Trend = trend / penultimateCustomer.Value * 100;
            }
            foreach (var customer in data)
            {
                result.Data.Add(customer);
                sum = sum + customer.Value;
            }
            result.Total = sum;
            return result;
        }

        public async Task<AdminModel> GetNumberTransaction()
        {

            var data = await _unitOfWork._transactionRepository.GetNumberTransaction();
            double sum = 0;
            var result = new AdminModel();
            result.Data = new List<AdminData>();
            if (data != null && data.Count > 1)
            {
                data = data.OrderBy(c => c.Date).ToList();
                var lastCustomer = data[^1];
                var penultimateCustomer = data[^2];
                var trend = lastCustomer.Value - penultimateCustomer.Value;
                if (penultimateCustomer.Value == 0)
                {
                    result.Trend = 0;
                }
                else
                    result.Trend = trend / penultimateCustomer.Value * 100;
            }
            foreach (var customer in data)
            {
                result.Data.Add(customer);
                sum = sum + customer.Value;
            }
            result.Total = sum;
            return result;
        }
        public async Task<List<AdminObjectData>> GetTrendingPackage()
        {
            var list = await _unitOfWork._packageRepository.GetDashboardPackages();
            return list;
        }

        public async Task<List<AdminObjectData>> CalculateTrendingPackages()
        {
            var list = await _unitOfWork._packageRepository.GetDashboardPricePackages();
            return list;
        }
        //
        public async Task<List<AdminObjectData>> GetQuantityRentingProduct()
        {
            var list = await _unitOfWork._itemsInUserPackageRepository.GetRentingProducts();
            return list;
        }
        public async Task<List<AdminObjectData>> GetQuantityUnReturnedProduct()
        {
            var list = await _unitOfWork._itemsInUserPackageRepository.GetUnReturnProducts();
            return list;
        }

        public async Task<AdminModel> GetCompletedOrder()
        {
            var data = await _unitOfWork._customerPackageRepository.GetDashboardCompleteOrder();
            double sum = 0;
            var result = new AdminModel();
            result.Data = new List<AdminData>();
            if (data != null && data.Count > 1)
            {
                data = data.OrderBy(c => c.Date).ToList();
                var lastCustomer = data[^1];
                var penultimateCustomer = data[^2];
                var trend = lastCustomer.Value - penultimateCustomer.Value;
                if (penultimateCustomer.Value == 0)
                {
                    result.Trend = 0;
                }
                else
                    result.Trend = trend / penultimateCustomer.Value * 100;
            }
            foreach (var customer in data)
            {
                result.Data.Add(customer);
                sum = sum + customer.Value;
            }
            result.Total = sum;
            return result;
        }
        public async Task<AdminModel> GetCanceledOrder()
        {
            var data = await _unitOfWork._customerPackageRepository.GetDashboardCancelOrder();
            double sum = 0;
            var result = new AdminModel();
            result.Data = new List<AdminData>();
            if (data != null && data.Count > 1)
            {
                data = data.OrderBy(c => c.Date).ToList();
                var lastCustomer = data[^1];
                var penultimateCustomer = data[^2];
                var trend = lastCustomer.Value - penultimateCustomer.Value;
                if (penultimateCustomer.Value == 0)
                {
                    result.Trend = 0;
                }
                else
                    result.Trend = trend / penultimateCustomer.Value * 100;
            }
            foreach (var customer in data)
            {
                result.Data.Add(customer);
                sum = sum + customer.Value;
            }
            result.Total = sum;
            return result;
        }
        public async Task<List<AdminObjectData>> GetLostProduct()
        {
            var list = await _unitOfWork._packageRepository.GetDashboardPackages();
            return list;
        }

    }
}
