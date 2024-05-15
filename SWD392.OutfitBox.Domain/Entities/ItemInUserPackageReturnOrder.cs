using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Domain.Entities
{
    public class ItemInUserPackageReturnOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public int ItemInUserPackageId { get; set; }
        [ForeignKey(nameof(ItemInUserPackageId))]   
        public ItemInUserPackage? ItemInUserPackage { get; set; }
        public int ReturnOrderId { get; set; }
        [ForeignKey("ReturnOrderId")]
        public ReturnOrder? ReturnOrder { get; set; }
    }
}
