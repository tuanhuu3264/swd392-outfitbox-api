using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin.Messaging;

namespace SWD392.OutfitBox.API.DTOs.Brand
{
    public class CreateBrandRequestDTO
    {
        [Required(ErrorMessage ="The name is required")]   
        
        public string? Name { get; set; }
        [Required(ErrorMessage = "The image is required")]
        public string? ImageUrl { get; set; } 
        public string? Description { get; set; }
    }
}
