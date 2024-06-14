using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Entities
{
    public class TransactionModel
    {
      
        public int Id { get; set; }
        public DateTime DateTransaction { get; set; }
        public double Amount { get; set; }
        public int Status { get; set; }
        public string Paymethod { get; set; } = string.Empty;
        public int WalletId { get; set; }   
        public int DepositId {  get; set; }
    }
}
