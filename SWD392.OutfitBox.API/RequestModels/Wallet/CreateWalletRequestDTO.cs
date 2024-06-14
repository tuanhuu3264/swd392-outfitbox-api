using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.Wallet
{
    public class CreateWalletRequestDTO
    {
        [Required(ErrorMessage = "The wallet code is required.")]
        public string WalletCode { get; set; } = string.Empty;
        [Required(ErrorMessage = "The wallet name is required.")]
        public string WalletName { get; set; } = string.Empty;
        [Required(ErrorMessage = "The wallet password is required.")]
        public string WalletPassword { get; set; } = string.Empty;
    }
}
