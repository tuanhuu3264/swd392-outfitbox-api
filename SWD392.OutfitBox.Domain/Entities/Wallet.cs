using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace SWD392.OutfitBox.Domain.Entities
{
    public class Wallet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string WalletCode { get; set; } = string.Empty;  
        public string WalletName { get; set; } = string.Empty;
        public string WalletPassword { get; set; } = string.Empty; 
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))] 
        public User? User { get; set; }
        public List<Deposit>? Deposits { get; set; } 
        public List<Transaction>? Transactions { get; set; }    

    }
}
