using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.Area
{ 
    public class CreateAreaRequestDTO
    {

        [Required(ErrorMessage ="The district is required.")]
        public string? District { get; set; }
        [Required(ErrorMessage = "The city is required.")]
        public string? City { get; set; } 
    }
}
