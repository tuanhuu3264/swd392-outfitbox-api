using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Entities
{
    public class ReviewData
    {
        public int PackageId {get; set; }
        public List<RatingStar> RatingStars { get; set; }
    }
    public class RatingStar
    {
        public int StarNumber { get; set; }
        public int Quantity { get; set; }
    }
}
