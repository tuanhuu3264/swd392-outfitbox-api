using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models.Responses.Category
{
    public class UpdateCategoryResponseDTO
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Status { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsFeatured { get; set; } = false;
    }
}
