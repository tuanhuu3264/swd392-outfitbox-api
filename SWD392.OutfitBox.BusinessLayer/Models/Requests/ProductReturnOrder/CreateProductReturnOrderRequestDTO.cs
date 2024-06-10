using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models.Requests.ProductReturnOrder
{
    public class CreateProductReturnOrderRequestDTO
    {
        public int Quantity { get; set; }
        public int Status { get; set; }
        public int ProductId { get; set; }
        public int ReturnOrderId { get; set; }

    }
}
