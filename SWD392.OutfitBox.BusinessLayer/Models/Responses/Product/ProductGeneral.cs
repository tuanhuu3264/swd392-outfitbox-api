using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models.Responses.Product
{
    public class ProductGeneral
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Size { get; set; } = string.Empty;
        public float Deposit { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; }= string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Brand { get; set; } =string.Empty;
        public string Type { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty; 
    }
}
