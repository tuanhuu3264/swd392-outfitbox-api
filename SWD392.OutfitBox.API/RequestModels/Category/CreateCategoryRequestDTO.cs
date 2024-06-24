using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.Category

{
    public class CreateCategoryRequestDTO
    {
        [Required(ErrorMessage ="The name is required.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "The description is required.")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "The image is required.")]
        public string? ImageUrl { get; set; } 

    }
}
