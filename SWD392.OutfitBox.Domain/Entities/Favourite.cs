﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Domain.Entities
{
    [Table("FavouriteProduct")]
    public class FavouriteProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("Customer")]
        public Customer? Customer  { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

    }
}
