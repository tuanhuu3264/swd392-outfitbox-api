using SWD392.OutfitBox.BusinessLayer.BusinessModels;
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

        public async Task<AdminModel> GetNumberTransaction(string kind)
        {

            switch (kind)
            {
                case "day":
                    var nowTDay = await _unitOfWork._transactionRepository.GetByDate(DateTime.Now);
                    var yesterdayTDay = await _unitOfWork._transactionRepository.GetByDate(DateTime.Now.Subtract(TimeSpan.FromDays(1)));
                    return new AdminModel
                    {
                        Total = nowTDay.Count(),
                        Trend = yesterdayTDay.Count() == 0 ? 0 : (nowTDay.Count() - yesterdayTDay.Count()) / (double)yesterdayTDay.Count()
                    };

                case "week":
                    var nowTWeek = await _unitOfWork._transactionRepository.GetByMonth(DateTime.Now);
                    var lastWeekTWeek = await _unitOfWork._transactionRepository.GetByMonth(DateTime.Now.Subtract(TimeSpan.FromDays(7)));
                    return new AdminModel
                    {
                        Total = nowTWeek.Count(),
                        Trend = lastWeekTWeek.Count() == 0 ? 0 : (nowTWeek.Count() - lastWeekTWeek.Count()) / (double)lastWeekTWeek.Count()
                    };

                case "month":
                    var nowTMonth = await _unitOfWork._transactionRepository.GetByMonth(DateTime.Now);
                    var lastMonthTMonth = await _unitOfWork._transactionRepository.GetByMonth(DateTime.Now.AddMonths(-1));
                    return new AdminModel
                    {
                        Total = nowTMonth.Count(),
                        Trend = lastMonthTMonth.Count() == 0 ? 0 : (nowTMonth.Count() - lastMonthTMonth.Count()) / (double)lastMonthTMonth.Count()
                    };

                default:
                    throw new ArgumentException("Invalid 'kind' parameter. Supported values are 'day', 'week', and 'month'.");
            }
        }
        public async Task<List<AdminOjectModel>> GetTrendingPackage(string kind)
        {
            switch (kind)
            {
                case "day":
                    var customerPackagesDay = await _unitOfWork._customerPackageRepository.GetAllCustomerPackage();
                    var currentPackagesDay = customerPackagesDay.Where(x => x.CreatedAt.Date == DateTime.Now.Date);
                    var yesterdayPackagesDay = customerPackagesDay.Where(x => x.CreatedAt.Date == DateTime.Now.Date.Subtract(TimeSpan.FromDays(1)));

                    var trendingPackagesDay = CalculateTrendingPackages(currentPackagesDay, yesterdayPackagesDay);
                    return trendingPackagesDay;

                case "month":
                    var customerPackagesMonth = await _unitOfWork._customerPackageRepository.GetAllCustomerPackage();
                    var currentPackagesMonth = customerPackagesMonth.Where(x => x.CreatedAt.Month == DateTime.Now.Month);
                    var lastMonthPackagesMonth = customerPackagesMonth.Where(x => x.CreatedAt.Month == DateTime.Now.AddMonths(-1).Month);

                    var trendingPackagesMonth = CalculateTrendingPackages(currentPackagesMonth, lastMonthPackagesMonth);
                    return trendingPackagesMonth;

                default:
                    throw new ArgumentException("Invalid 'kind' parameter. Supported values are 'day' and 'month'.");
            }
        }
        private List<AdminOjectModel> CalculateTrendingPackages(IEnumerable<CustomerPackage> currentPackages, IEnumerable<CustomerPackage> lastPackages)
        {
            var trendingPackages = currentPackages
                .GroupBy(cp => cp.PackageId)
                .Select(group => new AdminOjectModel
                {   
                    
                    Id = group.Key,
                    Name = group.First().Package.Name,
                    Quantity = group.Sum(cp => cp.Items.Sum(item => item.Quantity)),
                    Trend = lastPackages.Any() ? (currentPackages.Count() - lastPackages.Count()) / (double)lastPackages.Count() : 0
                })
                .ToList();

            return trendingPackages;
        }

        public async Task<List<AdminOjectModel>> GetQuantityRentigPoduct(string kind)
        {
            var customerPackagesDay = await _unitOfWork._customerPackageRepository.GetAllCustomerPackage();
            var currentPackagesDay = customerPackagesDay.Where(x => x.Id == 1).SelectMany(x=>x.Items).GroupBy(x=>x.ProductId).Select(x=>new AdminOjectModel() { 
            
            DateTime=DateTime.Now,
                Id = x.Select(x => x.Product).ToArray()[0].ID,
                Kind = kind,
                Name= x.Select(x => x.Product).ToArray()[0].Name,
                Quantity=x.Sum(x=>x.Quantity),
                Url= x.Select(x => x.Product).SelectMany(x => x.Images).ToArray()[0].Link,
            });
            return currentPackagesDay.OrderByDescending(x=>x.Quantity).ToList();
            
        }
        public async Task<List<AdminOjectModel>> GetQuantityUnReturnedPoduct(string kind)
        {
            var customerPackagesDay = await _unitOfWork._customerPackageRepository.GetAllCustomerPackage();
            var currentPackagesDay = customerPackagesDay.Where(x => x.Id == 2 && x.IsReturnedDeposit==false).SelectMany(x => x.Items).Where(x=>x.ReturnedQuantity<x.Quantity).GroupBy(x => x.ProductId).Select(x => new AdminOjectModel()
            {

                DateTime = DateTime.Now,
                Id = x.Select(x => x.Product).ToArray()[0].ID,
                Kind = kind,
                Name = x.Select(x => x.Product).ToArray()[0].Name,
                Quantity = x.Sum(x => x.Quantity),
                Url = x.Select(x => x.Product).SelectMany(x => x.Images).ToArray()[0].Link,
            });
            return currentPackagesDay.OrderByDescending(x => x.Quantity).ToList();

        }

        public async Task<AdminModel> GetCompletedOrder(string kind)
        {
            AdminModel model = new AdminModel();

            switch (kind)
            {
                case "day":
                    var customerPackagesDay = await _unitOfWork._customerPackageRepository.GetAllCustomerPackage();
                    var currentPackagesByDay = customerPackagesDay
                        .Where(x => x.CreatedAt.Year == DateTime.Now.Year && x.Status != -1)
                        .GroupBy(x => x.CreatedAt.Date)
                        .Select(group => new AdminData()
                        {
                            Date = group.Key,
                            Value = group.Count()
                        })
                        .ToList();

                    model.Data = currentPackagesByDay;
                    return model;

                case "month":
                    var customerPackagesMonth = await _unitOfWork._customerPackageRepository.GetAllCustomerPackage();
                    var currentPackagesByMonth = customerPackagesMonth
                        .Where(x => x.CreatedAt.Year == DateTime.Now.Year && x.Status != -1)
                        .GroupBy(x => x.CreatedAt.Month)
                        .Select(group => new AdminData()
                        {
                            Date = DateTime.Now,
                            Month=DateTime.Now.Month,
                            Value = group.Count()
                        })
                        .ToList();

                    model.Data = currentPackagesByMonth;
                    return model;

                default:
                    throw new ArgumentException("Invalid 'kind' parameter. Supported values are 'day' and 'month'.");
            }
        }
        public async Task<AdminModel> GetCanceledOrder(string kind)
        {
            AdminModel model = new AdminModel();

            switch (kind)
            {
                case "day":
                    var customerPackagesDay = await _unitOfWork._customerPackageRepository.GetAllCustomerPackage();
                    var currentPackagesByDay = customerPackagesDay
                        .Where(x => x.CreatedAt.Year == DateTime.Now.Year && x.Status == -1)
                        .GroupBy(x => x.CreatedAt.Date)
                        .Select(group => new AdminData()
                        {
                            Date = group.Key,
                            Value = group.Count()
                        })
                        .ToList();

                    model.Data = currentPackagesByDay;
                    return model;

                case "month":
                    var customerPackagesMonth = await _unitOfWork._customerPackageRepository.GetAllCustomerPackage();
                    var currentPackagesByMonth = customerPackagesMonth
                        .Where(x => x.CreatedAt.Year == DateTime.Now.Year && x.Status == -1)
                        .GroupBy(x => x.CreatedAt.Month)
                        .Select(group => new AdminData()
                        {
                            Date = DateTime.Now,
                            Month = DateTime.Now.Month,
                            Value = group.Count()
                        })
                        .ToList();

                    model.Data = currentPackagesByMonth;
                    return model;

                default:
                    throw new ArgumentException("Invalid 'kind' parameter. Supported values are 'day' and 'month'.");
            }
        }
        public async Task<AdminModel> GetLostProduct(string kind)
        {
            AdminModel model = new AdminModel();
            var customerPackagesMonth = await _unitOfWork._customerPackageRepository.GetAllCustomerPackage();
            switch (kind)
            {
                case "month":
                   
                    var currentPackagesByMonth = customerPackagesMonth
                        .Where(x => x.CreatedAt.Year == DateTime.Now.Year && x.CreatedAt.Date.Month == DateTime.Now.Month && x.Status == 2 && x.IsReturnedDeposit == true)
                        .SelectMany(x => x.Items).Where(x => x.ReturnedQuantity < x.Quantity).Select(x => x.Quantity - x.ReturnedQuantity).Sum();
                    var lastPackagesByMonth = customerPackagesMonth
                      .Where(x => x.CreatedAt.Year == DateTime.Now.Year && x.CreatedAt.Date.Month == DateTime.Now.Month-1 && x.Status == 2 && x.IsReturnedDeposit == true)
                      .SelectMany(x => x.Items).Where(x => x.ReturnedQuantity < x.Quantity).Select(x => x.Quantity - x.ReturnedQuantity).Sum();

                    return model = new AdminModel()
                    {
                        Total = currentPackagesByMonth,
                        Trend = (currentPackagesByMonth - lastPackagesByMonth) / lastPackagesByMonth
                    };
                case "year":
                    var currentPackagesByMonthV2 = customerPackagesMonth
                        .Where(x => x.CreatedAt.Year == DateTime.Now.Year && x.Status == 2 && x.IsReturnedDeposit == true)
                        .SelectMany(x => x.Items).Where(x => x.ReturnedQuantity < x.Quantity).Select(x => x.Quantity - x.ReturnedQuantity).Sum();

                    var lastPackagesByMonthV2 = customerPackagesMonth
                       .Where(x => x.CreatedAt.Year == DateTime.Now.Year-1&& x.Status == 2 && x.IsReturnedDeposit == true)
                       .SelectMany(x => x.Items).Where(x => x.ReturnedQuantity < x.Quantity).Select(x => x.Quantity - x.ReturnedQuantity).Sum();

                    return model = new AdminModel()
                    {
                        Total = currentPackagesByMonthV2,
                        Trend = (currentPackagesByMonthV2 - lastPackagesByMonthV2) / lastPackagesByMonthV2
                    };

                default:
                    throw new ArgumentException("Invalid 'kind' parameter. Supported values are 'day' and 'month'.");
            }
        }

    }
}
