using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Domain.Entities
{
    public class ReviewImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public int ReviewId { get; set; }
        [ForeignKey("ReviewId")]
        public Review? Review { get; set; }
    }
}
