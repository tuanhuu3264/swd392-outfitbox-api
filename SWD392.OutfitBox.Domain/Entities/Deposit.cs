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
        
        public List<Transaction>? Transactions { get; set; }
        
        public DateTime Date { get; set; }
        public long AmountMoney { get; set; }
        public string Type {  get; set; } = string.Empty;
        
        public int CustomerId {  get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }


    }
}
