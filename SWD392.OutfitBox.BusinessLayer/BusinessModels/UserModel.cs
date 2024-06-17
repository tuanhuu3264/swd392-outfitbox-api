using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.BusinessModels
{
    public class UserModel
    {
        public int? Id { get; set; }
        public string? Email { get; set; }
        public string Phone{ get; set; } = string.Empty;
        public int Status { get; set; }
        public int RoldeId { get; set; }
        public string? RoleName { get; set; }   
    }
}
