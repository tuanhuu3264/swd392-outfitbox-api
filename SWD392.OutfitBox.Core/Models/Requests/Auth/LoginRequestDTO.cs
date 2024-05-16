using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Models.Requests.Auth
{
    public class LoginRequestDTO
    {
        public string EmailOrPhone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
