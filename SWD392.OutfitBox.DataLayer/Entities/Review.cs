using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Entities
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Title { get; set; } =string.Empty;
        public int NumberStars { get; set; }
        public int Status {  get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int PackageId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer? User { get; set; }
        [ForeignKey(nameof(PackageId))]
        public Package? Package { get; set; }
        public List<ReviewImage>? ReviewImages { get; set; }

    }
}
