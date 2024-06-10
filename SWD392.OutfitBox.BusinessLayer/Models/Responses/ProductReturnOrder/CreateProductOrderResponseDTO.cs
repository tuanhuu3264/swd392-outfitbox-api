using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models.Responses.ProductReturnOrder
{
    public class CreateProductOrderResponseDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public int ProductId { get; set; }
        public int ReturnOrderId { get; set; }
        
    }
}
