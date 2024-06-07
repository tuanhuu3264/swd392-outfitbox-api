using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models.Requests.Package
{
    public class UpdatePackageRequestDTO
    {   
        public int Id { get; set; }
        
        public double Price { get; set; }
        public int AvailableRentDays { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public int Status { get; set; }

        public CategoryPackageDTO[]? CategoryPackages { get; set; }
    }
    
}
