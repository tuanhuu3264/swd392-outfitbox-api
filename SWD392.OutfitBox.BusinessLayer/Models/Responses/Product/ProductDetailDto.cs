using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models.Responses.Product
{
    public class ProductDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Size { get; set; }
        public float Deposit { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string IsUsed { get; set; }
        public CategoryDto Category{ get; set; }
        public BrandDto Brand { get; set; }
        public int Quantity {  get; set; }
        public int AvailableQuantity { get; set; }
        public string? Type { get; set; }
        public List<ImageDto>? Images { get; set; }
    }
    public class CategoryDto
    {
        public int Id { set; get; }
        public string Name { set; get; } = string.Empty;
    }
    public class BrandDto
    { 
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class ImageDto
    {
        public int Id { get; set; }
        public string Link { get; set; } = string.Empty;
    }
}
