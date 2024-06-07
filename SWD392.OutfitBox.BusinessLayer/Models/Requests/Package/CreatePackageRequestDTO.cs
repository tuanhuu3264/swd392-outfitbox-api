using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models.Requests.Package
{
    public class CreatePackageRequestDTO
    {
        public double Price { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public int Status { get; set; }
     
        public List<CategoryPackageDTO>? CategoryPackages { get; set; }
    }
    public class CategoryPackageDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int MaxAvailableQuantity { get; set; }
    }
}
