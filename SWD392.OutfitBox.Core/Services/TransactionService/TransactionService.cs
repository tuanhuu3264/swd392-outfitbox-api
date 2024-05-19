using AutoMapper;
using AutoMapper.Configuration.Annotations;
using SWD392.OutfitBox.Core.Models.Requests.Transaction;
using SWD392.OutfitBox.Core.Models.Responses.Transaction;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        ITransactionRepository _transactionRepository; 
        IPackageRepository _packageRepository;
        ICustomerPackageRepository _userPackageRepository;
        IItemsInUserPackage _itemsInUserPackage;
        IProductRepository _productRepository;
        IMapper _mapper;
        public TransactionService(IMapper mapper, IProductRepository productRepository, ICustomerPackageRepository userPackageRepository,
            IItemsInUserPackage itemsInUserPackage,IPackageRepository packageRepository, ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
            _packageRepository = packageRepository;
            _itemsInUserPackage = itemsInUserPackage;
            _userPackageRepository = userPackageRepository;
            _productRepository= productRepository;
            _mapper = mapper;
        }
        public async Task<string> Checkout(CheckoutTransactionRequestDTO checkoutTransactionRequestDTO)
        {
            var transaction = new Transaction()
            {
                WalletId = checkoutTransactionRequestDTO.WalletId,
                DateTransaction = DateTime.Now
            };
            var createdTransaction = await _transactionRepository.CreateTransaction(transaction);
            var package = await _packageRepository.GetPackageById(checkoutTransactionRequestDTO.PackageId);
            var userPackage = new CustomerPackage()
            {
                PackageId = checkoutTransactionRequestDTO.PackageId,
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now.AddDays(package.AvailableRentDays),
                PackageName = package.Name,
                Price = package.Price,
                ReceiverAddress = checkoutTransactionRequestDTO.ReceiverAddress,
                ReceiverName = checkoutTransactionRequestDTO.ReceiverName,
                ReceiverPhone = checkoutTransactionRequestDTO.ReceiverPhone,
                TransactionId = transaction.Id,
                CustomerId = checkoutTransactionRequestDTO.UserId,
            };
            userPackage.Status = 1;
            var createdUserPackage = _userPackageRepository.CreateUserPackage(userPackage);
            var itemsInUserPackage = checkoutTransactionRequestDTO.Items?.Select(async x => {
                var returnedItem = new ItemInUserPackage()
                {
                    ProductId = x.ProductId,
                    UserPackageId = createdUserPackage.Id,
                    Deposit = (await _productRepository.GetAll()).First(y => y.ID == x.ProductId).Deposit
                };
                return returnedItem;
            }).Select(x=>x.Result).ToList();
            var createdItemsInUserPackage = _itemsInUserPackage.CreateItemsInUserPackage(itemsInUserPackage.ToArray());
            return "Checkout successfully.";
        }

        public async Task<List<TransactionDTO>> GetAllTransactionsByUserId(int userId)
        {
            return (await _transactionRepository.GetAllTransactionsByUserId(userId)).Select(x=>_mapper.Map<TransactionDTO>(x)).ToList();
        }

        public async Task<List<TransactionDTO>> GetAllTransactionsByWalletId(int walletId, int userId)
        {
            return (await _transactionRepository.GetAllTransactionsByUserId(userId)).Where(x => x.WalletId == walletId).Select(x=>_mapper.Map<TransactionDTO>(x)).ToList();
        }
    }
}
