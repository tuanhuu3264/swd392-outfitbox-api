
using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SWD392.OutfitBox.DataLayer.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(Context context) : base(context)
        {
        }

        public async Task<Transaction> CreateTransaction(Transaction transaction)
        {
            var result = await this.AddAsync(transaction);
            await this.SaveChangesAsync(); 
            return await this.Get().OrderBy(x=>x.Id).LastAsync();
        }

        public Task<List<Transaction>> GetAllTransactionsByUserId(int userId)
        {
            return this.Get().Include(x => x.Wallet).ThenInclude(x => x.Customer).Where(x => x.Wallet != null && x.Wallet.Customer != null && x.Wallet.Customer.Id == userId).ToListAsync();
        }
    }
}
