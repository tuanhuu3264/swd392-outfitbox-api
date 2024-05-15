using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Models.Responses.Wallet
{
    public class CreateWalletResponseDTO
    {
        public string WalletCode { get; set; } = string.Empty;
        public string WalletName { get; set; } = string.Empty;
        public string WalletPassword { get; set; } = string.Empty;
        public int Status { get; set; }
        public int UserId { get; set; }
    }
}
