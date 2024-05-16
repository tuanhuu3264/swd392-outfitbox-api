using AutoMapper;
using SWD392.OutfitBox.Core.Models.Requests.Wallet;
using SWD392.OutfitBox.Core.Models.Responses.Wallet;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.WalletService
{
    public class WalletService : IWalletService
    {
        public IWalletRepository _walletRepository;
        public IMapper _mapper;
        public WalletService(IWalletRepository walletRepository, IMapper mapper) 
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }

        public async Task<WalletDTO> ActiveOrDeactiveWalletById(int id)
        {
            var wallet = await _walletRepository.GetWalletById(id);
            if (wallet == null) throw new Exception("Not found the wallet that has id: " + id); 
            wallet.Status= Math.Abs(1-wallet.Status);
            return _mapper.Map<WalletDTO>(await _walletRepository.UpdateWallet(wallet));
        }

        public async Task<CreateWalletResponseDTO> AddWalletWithUserId(int userId, CreateWalletRequestDTO wallet)
        {
            var result = _mapper.Map<Wallet>(wallet);
            result.UserId = userId; 
            var addedWallet = await _walletRepository.CreateWallet(userId, result);
            return _mapper.Map<CreateWalletResponseDTO>(addedWallet);
        }

        public async Task<List<WalletDTO>> GetAllEnabledWalletWithUserId(int userId)
        {
            return (await GetAllWalletWithUserId(userId)).Where(x => x.Status == 1).Select(x=> _mapper.Map<WalletDTO>(x)).ToList();
        }

        public async Task<List<WalletDTO>> GetAllWalletWithUserId(int userId)
        {
            return (await _walletRepository.GetAllWalletsByUserId(userId)).Select(x => _mapper.Map<WalletDTO>(x)).ToList() ;
        }

        public async Task<WalletDTO> GetWalletById(int id)
        {
           return _mapper.Map<WalletDTO>(await _walletRepository.GetWalletById(id));
        }

        public async Task<UpdateWalletResponseDTO> UpdateWalletWithUserId(int userId, UpdateWalletRequestDTO wallet)
        {   
            var result = _mapper.Map<Wallet>(wallet);
            result.UserId = userId;
            var updatedWallet = await _walletRepository.UpdateWallet(result);
            return _mapper.Map<UpdateWalletResponseDTO>(updatedWallet);

        }
    }
}
