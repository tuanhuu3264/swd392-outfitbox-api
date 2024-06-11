using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Entities
{
    public class Package
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int AvailableRentDays { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Status { get; set; }
        public List<CustomerPackage>? CustomerPackages { get; set; }
        public List<CategoryPackage>? CategoryPackages { get; set; }
        public int NumOfProduct {  get; set; }
        public bool IsFeatured { get; set; }
    }
}
