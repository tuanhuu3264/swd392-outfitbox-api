using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models
{
    public class PackageModel
    {
        
        public int Id { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int AvailableRentDays { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Status { get; set; }
        public int NumOfProduct {  get; set; }
        public bool IsFeatured { get; set; }
    }
}
