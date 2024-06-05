using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models.Requests.Auth
{
    public class VerifyOTPRequestDTO
    {  
        public int UserId { get; set; }
        public long OTP { get; set; }
    }
}
