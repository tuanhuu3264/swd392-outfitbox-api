using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD392.OutfitBox.Core.Models.Responses.Product;

namespace SWD392.OutfitBox.Core.Models.Requests.Product
{
    public class UpdateProductDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string IsUsed { get; set; }
        public double Deposit { get; set; }
        public int IdCategory { get; set; }
        public int IdBrand { get; set; }
        public string Type { get; set; }
        public List<ImageDto>? Images { get; set; }
    }
}
