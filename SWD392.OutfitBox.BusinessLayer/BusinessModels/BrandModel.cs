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
    public class BrandModel
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
        [JsonPropertyName("url")]
        public string? ImageUrl { get; set; } 
        public string? Description { get; set; }
        public int? Status {  get; set; }
        public bool? IsFeatured { get; set; }
    }
}
