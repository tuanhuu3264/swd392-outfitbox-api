using SWD392.OutfitBox.BusinessLayer.Models.Responses.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models.Responses.Auth
{
    public class VerifyOTPResponseDTO
    { 
        public string Message { get; set; } = string.Empty;
        public CustomerDTO UserProfile { get; set; } = new CustomerDTO();
    }
}
