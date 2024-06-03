﻿using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Models.Requests.ItemInUserPackage
{
    public class CreatedItemInPackage
    {
        public double Deposit { get; set; }
        public int Status { get; set; }
        public int ProductId { get; set; }
        public int UserPackageId { get; set; }
        public DateTime? DateGive { get; set; }
        public DateTime? DateReceive { get; set; }
        public double TornMoney { get; set; }
        public int Quantity { get; set; }
    }
}
