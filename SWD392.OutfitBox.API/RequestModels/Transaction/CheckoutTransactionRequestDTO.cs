using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.Transaction
{
    public class CheckoutTransactionRequestDTO
    {
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public int PackageId { get; set; }
        public DateTime DateFrom { get; set; }
        public string ReceiverName { get; set; } = string.Empty;
        public string ReceiverPhone { get; set; } = string.Empty;
        public string ReceiverAddress { get; set; } = string.Empty;
        public int AvailableRentDays { get; set; }
        public ItemInCheckoutTransactionRequestDTO[]? Items { get; set; }    
    }
    public class ItemInCheckoutTransactionRequestDTO
    {
        public int ProductId { get; set; }
        public double Deposit { get; set; }

    }
}
