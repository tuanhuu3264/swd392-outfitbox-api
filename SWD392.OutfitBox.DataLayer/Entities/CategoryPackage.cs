using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Entities
{
    public class CategoryPackage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MaxAvailableQuantity { get; set; }
        public int CategoryId { get; set; }
        public int PackageId { get; set; }
        public int Status {  get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
        [ForeignKey(nameof(PackageId))]
        public Package? Package { get; set; }
    }
}
