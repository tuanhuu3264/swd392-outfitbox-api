using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.BusinessModels
{
    public class CustomerModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; } 
        public string? Picture { get; set; } 
        public string? Email { get; set; } 
        public string? Phone { get; set; } 
        public string? Address { get; set; } 
        public int? Status { get; set; }
        public long? MoneyInWallet { get; set; }
    }
}
