using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Domain.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public float Price { get; set; }
        public string Size {  get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string IsUsed {  get; set; }
        public double Deposit { get; set; }
        public int IdCategory {  get; set; }
        [ForeignKey("IdCategory")]
        public Category Category { get; set; }
        public int IdBrand {  get; set; }
        [ForeignKey("IdBrand")]
        public Brand Brand { get; set; }
        public int IdType { get; set; }
        [ForeignKey("IdType")]
        public ProductType Type { get; set; }
    }
}
