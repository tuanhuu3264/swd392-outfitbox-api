using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.BusinessModels.PaymentModels
{
    public class CheckoutPackageModel
    {
       public CategoryPackageModel package {  get; set; }
       public List<WalletModel> wallets { get; set; }
       public CustomerModel customer { get; set; }
    }
}
