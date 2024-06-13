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
    }
}
