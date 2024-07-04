using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.BusinessModels
{
    public class PackageModel
    {
        public int? Id { get; set; }
        public double? Price { get; set; }
        [JsonPropertyName("url")]
        public string? ImageUrl { get; set; } 
        public int? AvailableRentDays { get; set; }
        public string? Name { get; set; } 
        public string? Description { get; set; } 
        public int? Status { get; set; }
        public int? NumOfProduct {  get; set; }
        public bool? IsFeatured { get; set; }
        public List<CategoryPackageModel> CategoryPackages {  get; set; }
    }
}
