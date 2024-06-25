
using SWD392.OutfitBox.API.DTOs.ProductReturnOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.ReturnOrder

{
    public class CreateReturnOrderRequestDTO
    {
        [Required(ErrorMessage = "The partner id is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The partner id is over range of data.")]
        public int PartnerId { get; set; }
        [Required(ErrorMessage = "The customer package id is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The customer package id is over range of data.")]
        public int CustomerPackageId { get; set; }
        [Required(ErrorMessage = "The date return is required.")]
       
        public DateTime DateReturn { get; set; }
        [Required(ErrorMessage = "The name is required.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "The address is required.")]
        public string Address { get; set; } = string.Empty;
        [Required(ErrorMessage = "The phone is required.")]
        public string Phone { get; set; } = string.Empty;
        public CreateProductReturnOrderRequestDTO[]? ProductReturnOrders { get; set; }
    }
}
