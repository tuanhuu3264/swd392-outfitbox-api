using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Models.Requests.Product
{
    public class CreatedProductDto
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public float Deposit { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string IsUsed { get; set; }
        public int IdCategory { get; set; }
        public int IdBrand { get; set; }
        public int IdType { get; set; }
        public List<string> ImageUrls { get; set; }

    }
}
