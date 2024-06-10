using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models.Responses.Auth
{
    public class LoginResponseDTO
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expiration {  get; set; }
        public string Message { get; set; } = string.Empty;
        public int CustomerId { get; set; } 
        public string GUID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
    }
}
