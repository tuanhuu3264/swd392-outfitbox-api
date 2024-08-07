﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Entities
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime Time { get; set; } = DateTime.Now;
        public int Status { get; set; }
        public long MoneyInWallet { get; set; }
        public List<CustomerPackage>? UserPackages { get; set; }
        public List<ReturnOrder>? ReturnOrders { get; set; }
        public List<Wallet>? Wallets { get; set; }
        public List<Review>? Reviews { get; set; }
    }
}
