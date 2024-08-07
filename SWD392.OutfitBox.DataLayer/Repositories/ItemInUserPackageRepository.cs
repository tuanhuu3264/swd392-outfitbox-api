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
using NetTopologySuite.Index.HPRtree;

namespace SWD392.OutfitBox.DataLayer.Repositories
{
    public class ItemInUserPackageRepository : BaseRepository<ItemInUserPackage>, IItemsInUserPackageRepository
    {
        public ItemInUserPackageRepository(Context context) : base(context)
        {
        }

        public async Task<ItemInUserPackage> CreateItemInUserPackage(ItemInUserPackage item)
        {
            var result = await this.AddAsync(item);
            return await this.GetById(result.Id);
        }

        public Task<ItemInUserPackage[]> CreateItemsInUserPackage(ItemInUserPackage[] itemInUserPackages)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ItemInUserPackage>> GetAllItemInPacket()
        {
            return await this.Get().Include(x=>x.Product).ToListAsync();
        }

        public async Task<ItemInUserPackage> GetById(int id)
        {
            return await this.Get().Include(x => x.Product).FirstOrDefaultAsync(x=> x.Id==id);
        }

        public async Task<bool> UnactiveStatus(ItemInUserPackage item)
        {
           item.Status = -1;
           await this.Update(item);
           return (await this.GetById(item.Id)).Status == -1;
           
        }

        public async Task<ItemInUserPackage> UpdateItem(ItemInUserPackage item)
        {
            await this.Update(item);
            await this.SaveChangesAsync();
            return await this.GetById(item.Id); ;
        }
        public async Task<bool> DeleteItem(int itemId)
        {
            var obj =  await this.GetById(itemId);
            await this.Delete(obj);
            return true;

        }
        public async Task<List<ItemInUserPackage>> GetByUserPackageId(int Id)
        {
            var obj = await this.Get().Where(x=>x.UserPackageId==Id).ToListAsync();
            return obj;
        }

        public async Task<List<AdminObjectData>> GetRentingProducts()
        {
            var groupedProducts = await this.Get()
            .Include(x => x.Product)
            .ThenInclude(x=>x.Images)
            .Where(x => x.Status == 1)
            .GroupBy(x => x.Product.ID)
            .Select(g => new
            {
            Product = g.First().Product,
            TotalQuantity = g.Sum(x => x.Quantity)
            })
            .ToListAsync();
            var result = groupedProducts.Select(x => new AdminObjectData { Id = x.Product.ID, Name = x.Product.Name, Value = x.TotalQuantity, Url = x.Product.Images.First().Link }).ToList();
            return result;
        }

        public async Task<List<AdminObjectData>> GetUnReturnProducts()
        {
            var groupedProducts = await this.Get()
            .Include(x => x.UserPackage)
            .Include(x => x.Product)
            .ThenInclude(x => x.Images)
            .Where(x => x.Status == 2 && x.UserPackage.IsReturnedDeposit==false)
            .GroupBy(x => x.Product.ID)
            .Select(g => new
            {
                Product = g.First().Product,
                TotalQuantity = g.Sum(x => x.Quantity)
            })
            .ToListAsync();
            var result = groupedProducts.Select(x => new AdminObjectData { Id = x.Product.ID, Name = x.Product.Name, Value = x.TotalQuantity, Url = x.Product.Images.First().Link }).ToList();
            return result;
        }
    }
}
