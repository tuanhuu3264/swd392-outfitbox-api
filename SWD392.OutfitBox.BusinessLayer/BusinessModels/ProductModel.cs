using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.BusinessModels
{

    public class ProductModel
    {
        
        public int? ID { get; set; }
        public string? Name { get; set; }
        public float? Price { get; set; }
        public string? Size { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public string? IsUsed { get; set; }
        public double? Deposit { get; set; }
        public int? IdCategory { get; set; }
        public int? Quantity { get; set; }
        public int? AvailableQuantity { get; set; }
        public int? IdBrand { get; set; }
        public string? Type { get; set; }
        public bool? IsFeatured { get; set; }
        public List<ImageModel> Images { get; set; }
    }
}
