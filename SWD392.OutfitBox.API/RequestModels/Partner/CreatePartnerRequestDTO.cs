using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.Partner
{
    public class CreatePartnerRequestDTO
    {
        [Required(ErrorMessage ="The name is required.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "The address is required.")]
        public string Address { get; set; } = string.Empty;
        [Required(ErrorMessage = "The phone is required.")]
        [Phone(ErrorMessage ="The phone format is invalid.")]
        public string Phone { get; set; } = string.Empty;
        [Required(ErrorMessage = "The email is required.")]
        [EmailAddress(ErrorMessage = "The email format is invalid.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "The area id is required.")]
        [Range(1, int.MaxValue, ErrorMessage ="The area id is over range of data.")]
        public int AreaId { get; set; }
    }
}
