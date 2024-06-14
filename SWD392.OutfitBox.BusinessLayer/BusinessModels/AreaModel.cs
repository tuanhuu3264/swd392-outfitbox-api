using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.BusinessModels
{
    public class AreaModel
    {
     
        public int? Id { get; set; }
        public string? Ward;
        public string? District { get; set; } 
        public string? City { get; set; } 
      
    }
}
