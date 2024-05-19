using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Models.Requests.CategoryPackage
{
    public class CreateCategoryPackageRequestDTO
    {
        public int CategoryId { get; set; } 
        public int PackageId {  get; set; }
        public int MaxAvailableQuantity { get; set; }
    }
}
