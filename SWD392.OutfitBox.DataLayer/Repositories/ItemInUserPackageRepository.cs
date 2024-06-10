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
            return await this.AddAsync(item);
        }

        public Task<ItemInUserPackage[]> CreateItemsInUserPackage(ItemInUserPackage[] itemInUserPackages)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ItemInUserPackage>> GetAllItemInPacket()
        {
            return await this.Get().ToListAsync();
        }

        public async Task<ItemInUserPackage> GetById(int id)
        {
            return await this.Get().FirstOrDefaultAsync(x=> x.Id==id);
        }

        public async Task<bool> UnactiveStatus(ItemInUserPackage item)
        {
            item.Status = -1;
            this.Update(item);
            
            return true;
        }

        public async Task<bool> UpdateItem(ItemInUserPackage item)
        {
            this.Update(item);
            await this.SaveChangesAsync();
  
            return true;
        }
    }
}
