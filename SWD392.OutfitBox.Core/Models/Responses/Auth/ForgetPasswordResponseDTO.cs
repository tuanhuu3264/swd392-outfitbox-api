using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Models.Responses.Auth
{
    public class ForgetPasswordResponseDTO
    {
        public int UserId { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
