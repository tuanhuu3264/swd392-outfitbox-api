﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Models.Responses.FavouriteProduct
{
    public class CreateFavouriteProductResponseDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId {  get; set; }
    }
}
