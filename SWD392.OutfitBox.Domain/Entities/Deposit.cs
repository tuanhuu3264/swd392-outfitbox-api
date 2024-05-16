using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Domain.Entities
{
    public class Deposit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int WalletId { get; set; }
        [ForeignKey(nameof(WalletId))]
        public Wallet? Wallet { get; set; }
        
        public DateTime DateWork { get; set; }
        public long AmountMoney { get; set; }
        public string TransactionCode { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;


    }
}
