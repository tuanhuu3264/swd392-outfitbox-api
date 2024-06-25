
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Entities
{
    
    public class FavouriteProductModel
    {
       
        public int? Id { get; set; }
        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }
    
    }
}
