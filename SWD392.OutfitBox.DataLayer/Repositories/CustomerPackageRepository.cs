﻿using Microsoft.EntityFrameworkCore;
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

namespace SWD392.OutfitBox.DataLayer.Repositories
{
    public class CustomerPackageRepository : BaseRepository<CustomerPackage>, ICustomerPackageRepository
    {
        public CustomerPackageRepository(Context context) : base(context)
        {
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
    }
}
