using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.ItemInUserPackage
{
    public class CreatedItemInPackage
    {
        [Required(ErrorMessage ="The user package id is required.")]
        [Range(1,int.MaxValue, ErrorMessage ="The UserPackageId is over range of data.")]
        public int UserPackageId { get; set; }
        [Required(ErrorMessage = "The deposit is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "The deposit is over range of data.")]
        public double Deposit { get; set; }
        [Required(ErrorMessage = "The product id is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The product id is over range of data.")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "The quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The quantity is over range of data.")]
        public int Quantity { get; set; }
    }
    public class CreatedListItemsInPackage
    {
        [Required(ErrorMessage = "The user package id is required.")]
        public int UserPackageId { get; set; }
        public List<CreatedItemInPackage>? createdItemInPackages { get; set; }
    }
}
