using SWD392.OutfitBox.Core.Models.Responses.Customer;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Models.Responses.Auth
{
    public class VerifyOTPResponseDTO
    { 
        public string Message { get; set; } = string.Empty;
        public CustomerDTO UserProfile { get; set; } = new CustomerDTO();
    }
}
