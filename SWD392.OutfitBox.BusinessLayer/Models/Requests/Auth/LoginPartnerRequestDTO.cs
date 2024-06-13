using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models.Requests.Auth
{
    public class LoginPartnerRequestDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
