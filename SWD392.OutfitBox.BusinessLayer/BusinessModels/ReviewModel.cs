using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.BusinessModels
{
    public class ReviewModel
    {
        public int? Id { get; set; }
        public string? Content { get; set; } 
        public string? Title { get; set; } 
        public int? NumberStars { get; set; }
        public int? Status {  get; set; }
        public DateTime? Date { get; set; }
        public int? CustomerId { get; set; }
        public int? PackageId { get; set; }
        public List<ReviewImageModel> Images { get; set; }
    }
}
