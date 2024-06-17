using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.CreatePackage
{
    public class CreateCategoryPackageRequestDTO
    {
        [Required(ErrorMessage = "The category id is required.")]
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "The category id is required.")]
        [Range(1, int.MaxValue)]
        public int PackageId {  get; set; }
        [Required(ErrorMessage = "The category id is required.")]
        [Range(1, int.MaxValue)]
        public int MaxAvailableQuantity { get; set; }
    }
}
