using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.BusinessModels
{
    public class AdminOjectModel
    {   
        public string Kind { get; set; }
        public DateTime DateTime { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double Trend { get; set; }
        public string? Url {  get; set; }
    }
}
