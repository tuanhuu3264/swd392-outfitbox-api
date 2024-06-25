using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.BusinessModels
{
    public class PartnerModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; } 
        public string? Address { get; set; } 
        public string? Phone { get; set; }  
        public string? Email {  get; set; } 
        public int? Status { get; set; }
        public int? AreaId { get; set; }
        public AreaModel Area { get; set; }
        public Coordinate Coordinate { get; set; }
    }
    public class Coordinate
    {
        public string? X { get; set; }
        public string? Y { get; set; }
    }
}
