
using SWD392.OutfitBox.BusinessLayer.Models.Requests.ItemInUserPackage;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.ItemInUserPackage;
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
        Task<List<ItemInUserPackageDto>> GetAll();
        Task<ItemInUserPackageDto> CreateItem(CreatedItemInPackage itemInPackage);
        Task<ItemInUserPackageDto> UpdateItem(UpdateItemInPackage updateItemInPackage);
        Task<bool> DeleteItem(int itemid);
    }
}
