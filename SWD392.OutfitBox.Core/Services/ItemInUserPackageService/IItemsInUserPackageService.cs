using SWD392.OutfitBox.Core.Constants;
using SWD392.OutfitBox.Core.Models.Requests.ItemInUserPackage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.ItemInUserPackageService
{
    public interface IItemsInUserPackageService
    {
        Task<StatusCodeResponse<List<ItemInUserPackageDto>>> GetAll();
        Task<StatusCodeResponse<ItemInUserPackageDto>> CreateItem(CreatedItemInPackage itemInPackage);
    }
}
