using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.RepoInterfaces
{
    public interface IWalletRepository
    {
        public Task<List<Wallet>> GetAllWalletsByUserId(int userId);
        public Task<Wallet> GetWalletById(int id);
        public Task<Wallet> CreateWallet(int userId, Wallet wallet);
        public Task<Wallet> ActiveOrDeactiveWalletById(int walletId);
        public Task<Wallet> UpdateWallet (Wallet wallet);
    }
}
