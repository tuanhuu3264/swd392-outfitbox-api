using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.Product
{
    public class UpdateProductDto
    {
        public string? Name { get; set; }
        public float? Price { get; set; }
        public string? Size { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public string? IsUsed { get; set; }
        public double? Deposit { get; set; }
        public int? IdCategory { get; set; }
        public int? IdBrand { get; set; }
        public string? Type { get; set; }
        public int? Quantity {  get; set; }
        public List<string>? Images { get; set; }
    }
}
