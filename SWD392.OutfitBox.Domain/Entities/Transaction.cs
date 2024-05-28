using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Domain.Entities
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateTransaction { get; set; }
        public double Amount { get; set; }
        public int Status { get; set; }
        public string Paymethod { get; set; } = string.Empty;
        public int WalletId { get; set; }
        [ForeignKey(nameof(WalletId))]
        public Wallet? Wallet { get; set; }

        public int DepositId {  get; set; }
        [ForeignKey(nameof(DepositId))]
        public Deposit? Deposit { get; set;}
        public List<CustomerPackage>? CustomerPackages { get; set; } 
    }
}
