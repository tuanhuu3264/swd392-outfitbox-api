using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models.Requests.Customer
{
    public class UpdateCustomerRequestDTO
    {   
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Status { get; set; }
        public long MoneyInWallet { get; set; }


    }
}
