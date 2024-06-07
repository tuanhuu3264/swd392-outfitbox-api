using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models.Requests.Wallet
{
    public class UpdateWalletRequestDTO
    {
        public string WalletCode { get; set; } = string.Empty;
        public string WalletName { get; set; } = string.Empty;
        public string WalletPassword { get; set; } = string.Empty;
    }
}
