using AutoMapper.Configuration.Annotations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.Package
{
    public class CreatePackageRequestDTO
    {
        [Required(ErrorMessage ="The price is required.")]
        [Range(0, double.MaxValue, ErrorMessage ="The price is over the range of data." )]
        public double Price { get; set; }
        [JsonPropertyName("url")]
        public string ImageUrl { get; set; } = string.Empty;
        [Required(ErrorMessage ="The name is required.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage ="The description is required.")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "The Available Rent Days  is required.")]
        public int AvailableRentDays { get; set; }
        [Required(ErrorMessage = "The status  is required.")]
        public int Status { get; set; }
        [Required(ErrorMessage = "The Number of Product   is required.")]
        public int NumOfProduct { get; set; }
        [Required(ErrorMessage = "The Is Featured   is required.")]
        public bool IsFeatured { get; set; }
        [JsonPropertyName("categories")]
        public List<CategoryPackageDTO>? CategoryPackages { get; set; }
    }
    public class CategoryPackageDTO
    {  
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int MaxAvailableQuantity { get; set; }
    }
}
