using SWD392.OutfitBox.Core.Models.Requests.ItemInUserPackage;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.RepoInterfaces
{
    public interface IItemsInUserPackageRepository
    {
        Task<List<ItemInUserPackage>> GetAllItemInPacket();
        Task<ItemInUserPackage> GetById(int id);
        Task<ItemInUserPackage> CreateItemInUserPackage(ItemInUserPackage item);
        Task<bool> UpdateItem(ItemInUserPackage item);
        Task<bool> UnactiveStatus(ItemInUserPackage item);
        Task<ItemInUserPackage[]> CreateItemsInUserPackage(ItemInUserPackage[] itemInUserPackages);
    }
}
