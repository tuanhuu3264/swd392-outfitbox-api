using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.TransactionService
{
    public interface ITransactionService
    {
 
        public Task<List<TransactionModel>> GetAllTransactionsByWalletId(int walletId, int userId);
        public Task<List<TransactionModel>> GetAllTransactionsByUserId(int userId);

    }
}
