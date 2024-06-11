﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models.Responses.Brand
{
    public class BrandDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Description { get; set; }
        public int Status { get; set; }
        public bool IsFeatured { get; set; }
    }
}
