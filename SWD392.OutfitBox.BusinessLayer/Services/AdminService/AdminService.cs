using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                data = data.OrderBy(c => c.Date).ToList();
                var lastCustomer = data[^1]; 
                var penultimateCustomer = data[^2];
                var trend = lastCustomer.Value - penultimateCustomer.Value;
                result.Trend = trend;
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
                result.Trend = trend;
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
                result.Trend = trend;
            }
            foreach (var customer in data)
          {
                result.Data.Add(customer);
                sum = sum + customer.Value;
          }
         result.Total = sum;
         return result;
        }
    }
}
