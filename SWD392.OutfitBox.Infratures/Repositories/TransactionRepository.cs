
using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Domain.Entities;
using SWD392.OutfitBox.Infrastructure.Databases.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SWD392.OutfitBox.Infrastructure.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(Context context) : base(context)
        {
        }

        public async Task<Domain.Entities.Transaction> CreateTransaction(Domain.Entities.Transaction transaction)
        {
            var result = await this.AddAsync(transaction);
            await this.SaveChangesAsync(); 
            return await this.Get().OrderBy(x=>x.Id).LastAsync();
        }

        public Task<List<Domain.Entities.Transaction>> GetAllTransactionsByUserId(int userId)
        {
            return this.Get().Include(x => x.Wallet).ThenInclude(x => x.User).Where(x => x.Wallet != null && x.Wallet.User != null && x.Wallet.User.Id == userId).ToListAsync();
        }
    }
}
