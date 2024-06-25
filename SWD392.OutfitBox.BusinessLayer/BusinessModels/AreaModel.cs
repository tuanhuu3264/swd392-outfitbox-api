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
        public string? Address { get; set; }
        public string? District { get; set; } 
        public string? City { get; set; } 
        public Coordinate? Coordinate {  get; set; }

    }
    public class Coordinate
    {
        public string? X { get; set; }
        public string? Y { get; set; }
    }
}
