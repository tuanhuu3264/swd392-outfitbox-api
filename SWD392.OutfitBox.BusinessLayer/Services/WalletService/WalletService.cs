using AutoMapper;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;

namespace SWD392.OutfitBox.BusinessLayer.Services.WalletService
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

        public async Task<WalletModel> ActiveOrDeactiveWalletById(int id)
        {
            var wallet = await _walletRepository.GetWalletById(id);
            if (wallet == null) throw new Exception("Not found the wallet that has id: " + id); 
            wallet.Status= Math.Abs(1-wallet.Status);
            return _mapper.Map<WalletModel>(await _walletRepository.UpdateWallet(wallet));
        }

        public async Task<WalletModel> AddWalletWithUserId(WalletModel wallet)
        {
            var result = _mapper.Map<Wallet>(wallet);
          
            result.Status = 1;
            var addedWallet = await _walletRepository.CreateWallet(result.CustomerId,result);
            return _mapper.Map<WalletModel>(addedWallet);
        }

        public async Task<List<WalletModel>> GetAllEnabledWalletWithUserId(int userId)
        {
            return (await GetAllWalletWithUserId(userId)).Where(x => x.Status == 1).Select(x=> _mapper.Map<WalletModel>(x)).ToList();
        }

        public async Task<List<WalletModel>> GetAllWalletWithUserId(int userId)
        {
            return (await _walletRepository.GetAllWalletsByUserId(userId)).Select(x => _mapper.Map<WalletModel>(x)).ToList() ;
        }

        public async Task<WalletModel> GetWalletById(int id)
        {
           return _mapper.Map<WalletModel>(await _walletRepository.GetWalletById(id));
        }

        public async Task<WalletModel> UpdateWalletWithUserId(WalletModel wallet)
        {   
            var result = _mapper.Map<Wallet>(wallet);
         
            var updatedWallet = await _walletRepository.UpdateWallet(result);
            return _mapper.Map<WalletModel>(updatedWallet);

        }
    }
}
