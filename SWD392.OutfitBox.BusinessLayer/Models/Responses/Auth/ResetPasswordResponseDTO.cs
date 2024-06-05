using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models.Responses.Auth
{
    public class ResetPasswordResponseDTO
    {
        public int CustomerId { get; set; }
        public string Message { get; set; } = string.Empty; 
    }
}
