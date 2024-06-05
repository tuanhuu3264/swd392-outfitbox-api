using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models.Responses.CategoryPackage
{
    public class CreateCategoryPackageResponseDTO
    {
        public int Id { get; set; }

        public int MaxAvailableQuantity { get; set; }
        public int CategoryId { get; set; }
        public int PackageId { get; set; }
        public int Status { get; set; }
    }
}
