using SWD392.OutfitBox.Core.Models.Requests.Transaction;
using SWD392.OutfitBox.Core.Models.Responses.Transaction;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.TransactionService
{
    public interface ITransactionService
    {
        public Task<string> Checkout(CheckoutTransactionRequestDTO transaction); 
        public Task<List<TransactionDTO>> GetAllTransactionsByWalletId(int walletId, int userId);
        public Task<List<TransactionDTO>> GetAllTransactionsByUserId(int userId);
    }
}
