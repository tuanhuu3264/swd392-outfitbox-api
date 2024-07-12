using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Interfaces
{
    public interface IItemsInUserPackageRepository
    {
        Task<List<ItemInUserPackage>> GetAllItemInPacket();
        Task<ItemInUserPackage> GetById(int id);
        Task<ItemInUserPackage> CreateItemInUserPackage(ItemInUserPackage item);
        Task<ItemInUserPackage> UpdateItem(ItemInUserPackage item);
        Task<bool> UnactiveStatus(ItemInUserPackage item);
        Task<ItemInUserPackage[]> CreateItemsInUserPackage(ItemInUserPackage[] itemInUserPackages);
        Task<bool> DeleteItem(int itemId);
        Task<List<ItemInUserPackage>> GetByUserPackageId(int id);
        Task<List<Product>> GetRentingProducts();
    }
}
