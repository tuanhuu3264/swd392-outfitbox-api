using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.ItemInUserPackage
{
    public class CreatedItemInPackage
    {
        public int UserPackageId { get; set; }
        public double Deposit { get; set; }
        public int Status { get; set; }
        public int ProductId { get; set; }
        public DateTime? DateGive { get; set; }
        public DateTime? DateReceive { get; set; }
        public double TornMoney { get; set; }
        public int Quantity { get; set; }
    }
    public class CreatedListItemsInPackage
    {
        public int UserPackageId { get; set; }
        public List<CreatedItemInPackage> createdItemInPackages { get; set; }
    }
}
