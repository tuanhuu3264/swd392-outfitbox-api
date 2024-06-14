using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models
{
    public class Partner
    {
       
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty; 
        public string Email {  get; set; } = string.Empty;
        public string Password {  get; set; } = string.Empty;
        public string OTP { get; set; } = string.Empty;
        public int Status { get; set; }
        public int AreaId { get; set; }
        [ForeignKey(nameof(AreaId))]
        public Area? Area { get; set; }
        public List<ReturnOrder>? ReturnOrders { get; set; }
    }
}
