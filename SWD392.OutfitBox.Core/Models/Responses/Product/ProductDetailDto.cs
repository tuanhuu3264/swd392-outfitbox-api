using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Models.Responses.Product
{
    public class ProductDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public float Deposit { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string IsUsed { get; set; }
        public string Category { get; set; }
        public BrandDto Brand { get; set; }
        public string Type { get; set; }
        public List<ImageDto> Images { get; set; }
    }
    public class BrandDto
    { 
        public int Id { get; set; }
        public string Name {  get; set; }
    }
    public class ImageDto
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public int IdProduct { get; set; }
    }
}
