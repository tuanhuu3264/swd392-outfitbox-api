using SWD392.OutfitBox.BusinessLayer.Models.Requests.Transaction;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.TransactionService
{
    public interface ITransactionService
    {
        public Task<string> Checkout(CheckoutTransactionRequestDTO transaction); 
        public Task<List<TransactionDTO>> GetAllTransactionsByWalletId(int walletId, int userId);
        public Task<List<TransactionDTO>> GetAllTransactionsByUserId(int userId);
    }
}
