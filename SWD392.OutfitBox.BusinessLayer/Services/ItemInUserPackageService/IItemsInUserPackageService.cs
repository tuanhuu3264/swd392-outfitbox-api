
using SWD392.OutfitBox.BusinessLayer.Models.Requests.ItemInUserPackage;
using SWD392.OutfitBox.DataLayer.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.ItemInUserPackageService
{
    public interface IItemsInUserPackageService
    {
        Task<StatusCodeResponse<List<ItemInUserPackageDto>>> GetAll();
        Task<StatusCodeResponse<ItemInUserPackageDto>> CreateItem(CreatedItemInPackage itemInPackage);
    }
}
