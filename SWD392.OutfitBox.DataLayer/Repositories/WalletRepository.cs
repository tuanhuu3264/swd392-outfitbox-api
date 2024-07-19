
using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer;
using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD392.OutfitBox.DataLayer.Interfaces;

namespace SWD392.OutfitBox.DataLayer.Repositories

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
            await this.Update(result);
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
            var wallets = await this.Get().Include(x => x.Customer).Where(x => x.Customer != null && x.CustomerId == userId).ToListAsync();
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
            await this.Update(wallet);
            await this.SaveChangesAsync();
            return await this.Get().FirstAsync(x=>x.Id==wallet.Id);
        }
        public async Task<Wallet> GetWalletByCode(string code, int customerid)
        {
            var wallet = await this.Get().FirstOrDefaultAsync(x => x.WalletCode == code && x.CustomerId==customerid);
            if (wallet == null) return new Wallet();
            return wallet;
        }
    }
}
