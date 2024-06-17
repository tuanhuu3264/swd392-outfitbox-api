
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.ItemInUserPackageService
{
    public interface IItemsInUserPackageService
    {
        Task<List<ItemInUserPackageModel>> GetAll();
        Task<ItemInUserPackageModel> CreateItem(ItemInUserPackageModel itemInPackage);
        Task<ItemInUserPackageModel> UpdateItem(ItemInUserPackageModel updateItemInPackage);
        Task<bool> DeleteItem(int itemid);
    }
}
