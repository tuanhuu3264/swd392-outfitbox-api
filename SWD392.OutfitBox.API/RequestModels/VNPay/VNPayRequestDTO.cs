using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.VNPay
{
    public class VNPayRequestDTO
    {
        public int userId { get; set; }
        [Url]
        public string urlResponse { get; set; } = null!;
    }
}
