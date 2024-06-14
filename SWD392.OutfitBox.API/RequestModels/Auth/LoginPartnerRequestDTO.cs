using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.Auth
{
    public class LoginPartnerRequestDTO
    {
        [EmailAddress(ErrorMessage = "The format is invalid.")]
        [Required(ErrorMessage = "The email is required.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "The email is required.")]
        public string? Password { get; set; }
    }
}
