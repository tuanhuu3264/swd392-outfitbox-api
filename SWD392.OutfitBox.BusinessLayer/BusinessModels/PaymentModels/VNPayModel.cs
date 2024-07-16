using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.BusinessModels.PaymentModels
{
    public class VNPayModel
    {
        [Url]
        public string urlResponse { get; set; } = null!;
    }
}
