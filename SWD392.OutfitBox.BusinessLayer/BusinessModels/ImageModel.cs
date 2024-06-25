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
    public class ImageModel
    {
        public int? ID { get; set; }
        [JsonPropertyName("url")]
        public string? Link { get; set; }
        public int? IdProduct { get; set; }
    }
}
