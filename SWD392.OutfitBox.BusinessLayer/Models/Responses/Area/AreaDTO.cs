using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models.Responses.Area
{
    public class AreaDTO
    {
        public int Id { get; set; }
        public string Ward = string.Empty;
        public string Distrinct { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}
