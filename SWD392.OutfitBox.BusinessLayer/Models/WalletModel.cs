using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace SWD392.OutfitBox.BusinessLayer.Models

{
    public class WalletModel
    {
        public int Id { get; set; }
        public string WalletCode { get; set; } = string.Empty;  
        public string WalletName { get; set; } = string.Empty;
        public int Status { get; set; }
        public int CustomerId { get; set; }  

    }
}
