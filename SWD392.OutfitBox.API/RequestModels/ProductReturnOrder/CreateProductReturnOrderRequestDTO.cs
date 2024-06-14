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
        [Required(ErrorMessage = "The quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The quantity is over range of data.")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "The product id is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The product id is over range of data.")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "The return order id is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The return order id is over range of data.")]
        public int ReturnOrderId { get; set; }

    }
}
