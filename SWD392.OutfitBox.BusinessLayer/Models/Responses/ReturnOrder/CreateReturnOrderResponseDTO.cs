﻿using SWD392.OutfitBox.BusinessLayer.Models.Requests.ProductReturnOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models.Responses.ReturnOrder
{
    public class CreateReturnOrderResponseDTO
    {   
        public int Id { get; set; }
        public int PartnerId { get; set; }
        public int CustomerPackageId { get; set; }
        public DateTime DateReturn { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public CreateProductReturnOrderRequestDTO[]? ProductReturnOrders { get; set; }
    }
}