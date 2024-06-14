using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.Role
{
    public class CreateRoleRequestDTO
    {
        [Required(ErrorMessage ="The name is required.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "The description is required.")]
        public string Description {  get; set; } = string.Empty;
    }
}
