using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models.Responses.ItemInUserPackage
{
    public class ItemInUserPackageDto
    {
        public int Id { get; set; }
        public double Deposit { get; set; }
        public int Status { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UserPackageId { get; set; }
        public DateTime? DateGive { get; set; }
        public DateTime? DateReceive { get; set; }
        public double TornMoney { get; set; }
        public int Quantity { get; set; }
    }

}
