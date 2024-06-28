using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace SWD392.OutfitBox.API.DTOs.Brand

{
    public class UpdateBrandRequestDTO
    {   
        public string? Name { get; set; }
        [JsonPropertyName("url")]
        public string? ImageUrl { get; set; }
        public bool? IsFeatured { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
    }
}
