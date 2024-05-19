﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Models.Responses.Review
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int NumberStars { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public List<string> ReviewImages { get; set; } = new List<string>();
    }
}
