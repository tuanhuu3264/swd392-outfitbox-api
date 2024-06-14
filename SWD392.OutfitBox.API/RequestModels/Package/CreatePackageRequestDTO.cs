using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.Package
{
    public class CreatePackageRequestDTO
    {
        [Required(ErrorMessage ="The price is required.")]
        [Range(0, double.MaxValue, ErrorMessage ="The price is over the range of data." )]
        public double Price { get; set; }
        [Required(ErrorMessage ="The name is required.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage ="The description is required.")]
        public string Description { get; set; } = string.Empty;
        
        public List<CategoryPackageDTO>? CategoryPackages { get; set; }
    }
    public class CategoryPackageDTO
    {  
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int MaxAvailableQuantity { get; set; }
    }
}
