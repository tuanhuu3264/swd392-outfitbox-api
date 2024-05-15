using SWD392.OutfitBox.Core.Models.Requests.Wallet;
using SWD392.OutfitBox.Core.Models.Responses.Wallet;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.WalletService
{
    public interface IWalletService
    {
        public Task<List<WalletDTO>> GetAllEnabledWalletWithUserId(int userId); 
        public Task<List<WalletDTO>> GetAllWalletWithUserId (int userId);
        public Task<WalletDTO> GetWalletById (int id);
        public Task<CreateWalletResponseDTO> AddWalletWithUserId (int userId, CreateWalletRequestDTO wallet);
        public Task<UpdateWalletResponseDTO> UpdateWalletWithUserId (int userId, UpdateWalletRequestDTO wallet);
        public Task<WalletDTO> ActiveOrDeactiveWalletById(int id);
    }
}
