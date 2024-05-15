using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Domain.Entities
{
    public class ItemInUserPackage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long Deposit {  get; set; }
        public DateTime DateGive { get; set; }
        public DateTime DateReceive { get; set; }
        public int Status {  get; set; }
        public int ProductId { get; set; }
        public int UserPackageId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        [ForeignKey("UserPackageId")]
        public UserPackage? UserPackage { get; set; }
    }
}
