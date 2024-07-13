using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using SWD392.OutfitBox.DataLayer.Repositories.Interfaces;
using Abp.Linq.Expressions;
using Google.Api;
using Context = SWD392.OutfitBox.DataLayer.Databases.Redis.Context;
using System.Globalization;
using Azure.Identity;

namespace SWD392.OutfitBox.DataLayer.Repositories
{
    public class CustomerPackageRepository : BaseRepository<CustomerPackage>, ICustomerPackageRepository
    {
        internal Context _context;
        public CustomerPackageRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<CustomerPackage> CreateUserPackage(CustomerPackage userPackage)
        {
            var result = await this.AddAsync(userPackage);
            await this.SaveChangesAsync();
            return await this.Get().FirstAsync(x=>x.Id==userPackage.Id);
        }
        public async Task<CustomerPackage> GetCustomerPackageById(int id)
        {
            return await this.Get().Include(x=>x.Items).FirstOrDefaultAsync(x=>x.Id==id);
        }
        public async Task<List<CustomerPackage>> GetCustomerPackageByCustomerId(int customerId)
        {
            return await this.Get().Include(x => x.Items).Where(x => x.CustomerId == customerId).ToListAsync();
        }
        public async Task<CustomerPackage> SaveAsyn(CustomerPackage customerPacket)
        {
            await this.Update(customerPacket);
            await this.SaveChangesAsync();
            return await GetCustomerPackageById(customerPacket.Id);
        }
        public async Task<CustomerPackage> GetCustomerPackgageAndItemsbyId(int id)
        {
            return await this.Get().Include(x=>x.Items).Include(x=>x.Package).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AdminData>> GetTotalPackagePrice()
        {
            var data = await this.Get().GroupBy(x => x.DateFrom.Date).OrderBy(x => x.Key).Select(g => new AdminData
            {
                Date = g.Key,
                Value = g.Sum(x=>x.Price)
            }
            ).ToListAsync();
            return data;
        }

        public async Task<List<AdminData>> GetDailyOrders()
        {
            var data = await this.Get().GroupBy(x => x.DateFrom.Date).OrderBy(x => x.Key).Select(g => new AdminData
            {
                Date = g.Key,
                Value = g.Count()
            }
            ).ToListAsync();
            return data;
        }

        public async Task<List<CustomerPackage>> GetCustomerPackageByStatus(int status)
        {
            return await this.Get().Include(x => x.Items).Where(x=>x.Status==status).ToListAsync();
        }
        public async Task<List<CustomerPackage>> GetListOrder(
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
     double? minTotalDeposit = null)
        {
            var predicate = PredicateBuilder.New<CustomerPackage>(true);
            predicate.And(x => true);
            if (!string.IsNullOrEmpty(packageName))
            {
                predicate = predicate.And(x => x.PackageName.ToLower().Contains(packageName.ToLower()));
            }
            if (customerId.HasValue)
            {
                predicate = predicate.And(x => x.CustomerId == customerId.Value);
            }
            if (packageId.HasValue)
            {
                predicate = predicate.And(x => x.PackageId == packageId.Value);
            }
            if (status.HasValue)
            {
                predicate = predicate.And(x => x.Status == status.Value);
            }
            if (dateFrom.HasValue)
            {
                predicate = predicate.And(x => x.DateFrom >= dateFrom.Value);
            }
            if (dateTo.HasValue)
            {
                predicate = predicate.And(x => x.DateTo <= dateTo.Value);
            }
            if (!string.IsNullOrEmpty(receiverName))
            {
                predicate = predicate.And(x => x.ReceiverName.ToLower().Contains(receiverName.ToLower()));
            }
            if (!string.IsNullOrEmpty(receiverPhone))
            {
                predicate = predicate.And(x => x.ReceiverPhone.ToLower().Contains(receiverPhone.ToLower()));
            }
            if (!string.IsNullOrEmpty(receiverAddress))
            {
                predicate = predicate.And(x => x.ReceiverAddress.ToLower().Contains(receiverAddress.ToLower()));
            }
            if (maxPrice.HasValue)
            {
                predicate = predicate.And(x => x.Price <= maxPrice.Value);
            }
            if (minPrice.HasValue)
            {
                predicate = predicate.And(x => x.Price >= minPrice.Value);
            }
            if (transactionId.HasValue)
            {
                predicate = predicate.And(x => x.TransactionId == transactionId.Value);
            }
            if (quantityOfItems.HasValue)
            {
                predicate = predicate.And(x => x.QuantityOfItems == quantityOfItems.Value);
            }
            if (maxTotalDeposit.HasValue)
            {
                predicate = predicate.And(x => x.TotalDeposit <= maxTotalDeposit.Value);
            }
            if (minTotalDeposit.HasValue)
            {
                predicate = predicate.And(x => x.TotalDeposit >= minTotalDeposit.Value);
            }

            Func<IQueryable<CustomerPackage>, IOrderedQueryable<CustomerPackage>> orderBy = null;
            if (!string.IsNullOrEmpty(orders) && !string.IsNullOrEmpty(sorted))
            {
                string CapitalizeFirstLetter(string str)
                {
                    if (string.IsNullOrEmpty(str))
                        return str;
                    return char.ToUpper(str[0]) + str.Substring(1);
                }
                string formattedSorted = CapitalizeFirstLetter(sorted);
                orderBy = (query) =>
                {

                    if (orders.ToLower().Equals("desc"))
                    {
                        query = query.OrderByDescending(x => EF.Property<CustomerPackage>(x, formattedSorted));
                    }
                    else
                    {
                        query = query.OrderBy(x => EF.Property<CustomerPackage>(x, formattedSorted));
                    }
                    return (IOrderedQueryable<CustomerPackage>)query;

                };
            }

            var result = (await this.Get(predicate, orderBy, x => x.Include("Items"), pageIndex, pageSize)).ToList();
            return result;

           
        }
    }
}
