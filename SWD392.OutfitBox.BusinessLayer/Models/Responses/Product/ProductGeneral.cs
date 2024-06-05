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
        public string Name { get; set; }
        public float Price { get; set; }
        public string Size { get; set; }
        public float Deposit { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string ImgUrl { get; set; }
    }
}
