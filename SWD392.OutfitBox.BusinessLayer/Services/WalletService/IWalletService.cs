
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.WalletService
{
    public interface IWalletService
    {
        public Task<List<WalletModel>> GetAllEnabledWalletWithUserId(int userId); 
        public Task<List<WalletModel>> GetAllWalletWithUserId (int userId);
        public Task<WalletModel> GetWalletById (int id);
        public Task<WalletModel> AddWalletWithUserId (WalletModel wallet);
        public Task<WalletModel> UpdateWalletWithUserId (WalletModel wallet);
        public Task<WalletModel> ActiveOrDeactiveWalletById(int id);
    }
}
