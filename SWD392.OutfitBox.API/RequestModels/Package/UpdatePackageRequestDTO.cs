using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.Package
{
    public class UpdatePackageRequestDTO
    {   
        
        public double? Price { get; set; }
        public int? AvailableRentDays { get; set; }
        [JsonPropertyName("url")]
        public string ImageUrl { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public int? NumOfProduct { get; set; }

        public string? Description { get; set; } = string.Empty;
        public bool? IsFeatured { get; set; }
        public int? Status { get; set; }

        public CategoryPackageDTO[]? CategoryPackages { get; set; }
    }
    
}
