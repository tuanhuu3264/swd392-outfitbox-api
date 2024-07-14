using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.BusinessModels.PaymentModels
{
    public class ProductInReturnOrderViewModel
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public int ProductId { get; set; }
        
        public int ReturnOrderId { get; set; }
        public int Quantity { get; set; }
        public double ThornMoney { get; set; }
        public string? Description { get; set; }
        public ProductModel? Product { get; set; }
    }
}
