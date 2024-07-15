using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.BusinessModels.AdminModel
{
    public class AdminModel
    {
        public List<AdminData> Data { get; set; }
        public double Trend { get; set; }
        public double Total { get; set; }
    }
}
