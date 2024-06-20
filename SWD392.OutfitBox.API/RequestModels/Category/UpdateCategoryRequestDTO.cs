﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.Category
{
    public class UpdateCategoryRequestDTO
    {
        public string? Name { get; set; } 
        public string? Description { get; set; } 
        public int? Status { get; set; }
        public string? ImageUrl { get; set; } 
    }
}