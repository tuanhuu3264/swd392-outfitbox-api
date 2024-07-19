//using AutoMapper;
//using AutoMapper.Configuration.Annotations;
//using SWD392.OutfitBox.BusinessLayer.Models.Requests.Transaction;
//using SWD392.OutfitBox.BusinessLayer.Models.Responses.Transaction;
//using SWD392.OutfitBox.DataLayer.RepoInterfaces;
//using SWD392.OutfitBox.DataLayer.Entities;
//using SWD392.OutfitBox.DataLayer.Interfaces;

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SWD392.OutfitBox.DataLayer.Repositories.Interfaces;
//using SWD392.OutfitBox.BusinessLayer.BusinessModels;

using AutoMapper;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.UnitOfWork;

namespace SWD392.OutfitBox.BusinessLayer.Services.TransactionService
{ 
    public class TransactionService : ITransactionService
    {
       
        public IUnitOfWork _unitOfWork {  get; set; }
        public IMapper _mapper; 
        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
         }
        public async Task<List<TransactionModel>> GetAllTransactionsByUserId(int userId)
       {
           return (await _unitOfWork._transactionRepository.GetAllTransactionsByUserId(userId)).Select(x => _mapper.Map<TransactionModel>(x)).ToList();        }

       public async Task<List<TransactionModel>> GetAllTransactionsByWalletId(int walletId, int userId)
        {
          return (await _unitOfWork._transactionRepository.GetAllTransactionsByUserId(userId)).Where(x => x.WalletId == walletId).Select(x => _mapper.Map<TransactionModel>(x)).ToList();
      }
  }
}
