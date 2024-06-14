using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Entities
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Title { get; set; } =string.Empty;
        public int NumberStars { get; set; }
        public int Status {  get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    }
}
