
using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
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
            return result;
        }

        public async Task<List<Transaction>> GetAllTransactionsByUserId(int userId)
        {
            return await this.Get().Include(x => x.Wallet).ThenInclude(x => x.Customer).Where(x => x.Wallet != null && x.Wallet.Customer != null && x.Wallet.Customer.Id == userId).ToListAsync();
        }
        public async Task<Transaction> GetTransactionsByVNPayCode(string code)
        {
            return await this.Get().FirstOrDefaultAsync(x=>x.VNPayID==code);
        }

        public async Task<List<Transaction>> GetByDate(DateTime date)
        {
            var result = await this.Get().Where(x => x.DateTransaction.Date == date).ToListAsync();
            return result;
        }
        public async Task<List<Transaction>> GetByMonth(DateTime date)
        {
            var result = await this.Get().Where(x => x.DateTransaction!=null && x.DateTransaction.Month == date.Month && x.DateTransaction.Year==date.Year).ToListAsync();
            return result;
        }
        public async Task<List<Transaction>> GetByYear(DateTime date)
        {
            var result = await this.Get().Where(x => x.DateTransaction!=null && x.DateTransaction.Year == date.Year).ToListAsync();
            return result;
        }
    }
}
