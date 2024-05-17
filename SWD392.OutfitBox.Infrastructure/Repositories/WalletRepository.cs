
using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Domain;
using SWD392.OutfitBox.Domain.Entities;
using SWD392.OutfitBox.Infrastructure.Databases.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Infrastructure.Repositories
{
    public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(Context context) : base(context)
        {
        }

        public async Task<Wallet> ActiveOrDeactiveWalletById(int walletId)
        {
            var result = await this.Get().FirstAsync(x=>x.Id==walletId);
            result.Status = 1 - result.Status;
            this.Update(result);
            await this.SaveChangesAsync();
            return result;
        }

        public async Task<Wallet> CreateWallet(int userId, Wallet wallet)
        {
            var result = await this.AddAsync(wallet);
            await this.SaveChangesAsync();
            return result;
        }

        public async Task<List<Wallet>> GetAllWalletsByUserId(int userId)
        {
            var wallets = await this.Get().Include(x => x.User).Where(x => x.User != null && x.UserId == userId).ToListAsync();
            return wallets;
        }

        public async Task<Wallet> GetWalletById(int id)
        {
            var wallet = await this.Get().FirstOrDefaultAsync(x => x.Id == id);
            if (wallet == null) return new Wallet(); 
            return wallet;
        }

        public async Task<Wallet> UpdateWallet(Wallet wallet)
        {
            this.Update(wallet);
            await this.SaveChangesAsync();
            return await this.Get().FirstAsync(x=>x.Id==wallet.Id);
        }
    }
}
