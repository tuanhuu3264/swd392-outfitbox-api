﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Entities
{
    public class ReturnOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateReturn { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone {  get; set; } = string.Empty;  
        public int Status { get; set; }
        public int QuantityOfItems { get; set; }
        public int CustomerPackageId { get; set; }
        public double TotalThornMoney { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey(nameof(CustomerPackageId))]
        public CustomerPackage? CustomerPackage { get; set; }
        public int PartnerId { get; set; }
        [ForeignKey(nameof(PartnerId))]
        public Partner? Partner { get; set; }
        public List<ProductReturnOrder>? ProductReturnOrders { get; set; }
    }
}
