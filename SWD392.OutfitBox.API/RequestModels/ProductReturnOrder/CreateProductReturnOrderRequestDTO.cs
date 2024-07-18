using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.ProductReturnOrder
{
    public class CreateProductReturnOrderRequestDTO
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int DamagedLevel { get; set; }
     
        public double ThornMoney { get; set; }
        public string? Description { get; set; }

    }
}
