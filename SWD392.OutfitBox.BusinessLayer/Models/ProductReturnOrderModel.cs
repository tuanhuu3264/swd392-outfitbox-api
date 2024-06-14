using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Entities
{
    public class ProductReturnOrder
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public int ProductId { get; set; }         
        public int ReturnOrderId { get; set; }
        public int Quantity { get; set; }
    }
}
