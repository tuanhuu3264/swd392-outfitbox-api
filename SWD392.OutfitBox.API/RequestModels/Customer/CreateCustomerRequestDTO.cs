using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.Customer
{
    public class CreateCustomerRequestDTO
    {
        [Required(ErrorMessage ="The name is required.")]   
        
        public string Name { get; set; } = string.Empty;
        [EmailAddress(ErrorMessage = "The email format is invalide.")]
        [Required(ErrorMessage = "The email is required.")]
        public string Email { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        [Phone(ErrorMessage = "The phone format is invalid.")]
        [Required(ErrorMessage = "The phone is required.")]
        public string Phone { get; set; } = string.Empty;
        [Required(ErrorMessage ="The address is required.")]
        public string Address { get; set; } = string.Empty;
    }
}
