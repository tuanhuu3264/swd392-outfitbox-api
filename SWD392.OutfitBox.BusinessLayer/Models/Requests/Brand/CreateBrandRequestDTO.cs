using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin.Messaging;

namespace SWD392.OutfitBox.BusinessLayer.Models.Requests.Brand
{
    public class CreateBrandRequestDTO
    {
        [Required(ErrorMessage ="Name of brand is required")]   
        
        public string? Name { get; set; }
        [Required(ErrorMessage = "Image of brand is required")]
        public string? ImageUrl { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
