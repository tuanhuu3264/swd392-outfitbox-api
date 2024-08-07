﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD392.OutfitBox.DataLayer.Entities;

namespace SWD392.OutfitBox.BusinessLayer.BusinessModels
{
    public class ReturnOrderModel
    {

        public int? Id { get; set; }
        public DateTime? DateReturn { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public int? Status { get; set; }
        public double? TotalThornMoney { get; set; }
        public int? CustomerId { get; set; }
        public int? PartnerId { get; set; }
        public int? QuantityOfItems { get; set; }
        public int? CustomerPackageId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public List<ProductReturnOrderModel>? ProductReturnOrders {  get; set; } 

    }
}
