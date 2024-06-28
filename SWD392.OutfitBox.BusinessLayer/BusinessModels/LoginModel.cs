using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.BusinessModels
{
    public class LoginModel
    {
        public string? RefreshToken { get; set; }
        public string? Token { get; set; }
        public DateTime? Expiration {  get; set; }
        public int? Id { get; set; }
        public string? Picture { get; set; }
        public string? Guid { get; set; }
        public string? Email { get; set; }
    }
}
