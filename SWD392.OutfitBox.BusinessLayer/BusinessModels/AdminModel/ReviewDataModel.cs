using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.BusinessModels.AdminModel
{
    public class ReviewDataModel
    {
        public int PackageId { get; set; }
        public int QuantityOfReviews { get; set; }
        public double AverageStar { get; set; }
        public List<RatingStarModel> RatingStars { get; set; }
    }
    public class RatingStarModel
    {
        public int StarNumber { get; set; }
        public int Quantity { get; set; }
        public double Rate { get; set; }
    }
}
