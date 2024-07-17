using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.BusinessModels
{
    public class ItemInUserPackageModel
    {
        public int? Id { get; set; }
        public double? Deposit {  get; set; }
        public int? Status {  get; set; }
        public int? ProductId { get; set; }
        public int? UserPackageId { get; set; }
        public double? TornMoney {  get; set; }
        public int? Quantity { get; set; }
        public int? ReturnedQuantity { get; set; }
    }
}
