﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.BusinessModels
{
    public class ReviewImageModel
    {
        public int? Id { get; set; }
        public string? Url { get; set; }
        public int? ReviewId { get; set; }
    }
}
