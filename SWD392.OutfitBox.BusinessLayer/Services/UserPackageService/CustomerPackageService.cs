using Abp.Domain.Uow;
using Abp.Extensions;
using AutoMapper;
using Azure.Core;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.BusinessModels.PaymentModels;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using IUnitOfWork = SWD392.OutfitBox.DataLayer.UnitOfWork.IUnitOfWork;

namespace SWD392.OutfitBox.BusinessLayer.Services.UserPackageService
{
    public class CustomerPackageService : ICustomerPackageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CustomerPackageService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CustomerPackageModel> ChangeStatus(int id , int status)
        {
            using (_unitOfWork.BenginTransaction())
            {
                var customerPackageModel = await _unitOfWork._customerPackageRepository.GetCustomerPackgageAndItemsbyId(id);
                if (customerPackageModel == null) { throw new Exception("Not Found this CustomerPackage"); }
                if (customerPackageModel.Status == status) { throw new Exception("This CustomerPackage already has been this status"); }
                //0 la thanh toan thanh cong
                //1 la dang cho duyet
                //2 la dang thue
                //3 la het han thue
                if (status == 0)
                {
                    foreach (var item in customerPackageModel.Items)
                    {
                        var product = await _unitOfWork._productRepository.GetById(item.ProductId);
                        if (product == null) { throw new Exception("This Product is Not Found"); }
                        product.AvailableQuantity = product.AvailableQuantity - item.Quantity;
                        if (product.AvailableQuantity < 0)
                        {
                            await _unitOfWork.RollbackTransaction();
                            throw new Exception("Sorry, This Quantity of Product is not Enough");
                        }
                        await _unitOfWork._productRepository.UpdateProduct(product);
                    }
                }
                customerPackageModel.Status = status;
                await _unitOfWork._customerPackageRepository.SaveAsyn(customerPackageModel);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransaction();
                return _mapper.Map<CustomerPackageModel>(customerPackageModel);
            }       
        }
        public async Task<CustomerPackageModel> CreateCustomerPackage(CustomerPackageModel customerPackageModel, int walletId)
        {
            var customerPackage = _mapper.Map<CustomerPackage>(customerPackageModel);

            var package = await _unitOfWork._packageRepository.GetPackageById(customerPackage.PackageId);
            if (package == null) throw new Exception("There is no package that has id: " +customerPackage.PackageId);

            var user = await _unitOfWork._customerRepository.GetCustomerById(customerPackage.CustomerId);
            if(user == null ) throw new Exception("There is no customer that has id: " + customerPackage.CustomerId);

            var wallet = await _unitOfWork._walletRepository.GetWalletById(walletId);
            if (wallet  == null) throw new Exception("There is no wallet that has id: " + walletId);
            
            

            customerPackage.PackageName = package.Name;
            customerPackage.DateTo = customerPackage.DateFrom.AddDays(package.AvailableRentDays);
            customerPackage.Price = package.Price;
            customerPackage.Status = 0;
            customerPackage.TotalDeposit = 0;
            
            // check tổng số lượng sản phẩm phải nhỏ hơn tổng số lượng quy định 
            var numberProducts = customerPackageModel.ItemInUsers.Sum(x=>x.Quantity);
            if (numberProducts > package.NumOfProduct) throw new Exception("Number of products is over required number");
            
            // check số lượng sản phẩm có phù hợp không
            if(customerPackage.Items != null) 
            foreach (var item in customerPackage.Items)
            {
                var product = await _unitOfWork._productRepository.GetById(item.ProductId);
                if (item.Quantity > product.Quantity) throw new Exception($"The quantity of product {product.Name} is over availabled number");
            }

            // check số lượng category có phù hợp không 
            Dictionary<int, int>  categoryPackage = new Dictionary<int, int>();
            var categoryPackages = await _unitOfWork._categoryPackageRepository.GetAllCategoryPackagesByPackageId(package.Id);
            foreach(var category in categoryPackages) 
            {
                categoryPackage.Add(category.Id, category.MaxAvailableQuantity);
            }
            if(customerPackage.Items!=null)
            foreach(var item in customerPackage.Items)
            {
                    var product = await _unitOfWork._productRepository.GetById(item.Id);
                    var valueAvailableQuantiy = categoryPackage.GetValueOrDefault(product.IdCategory);
                    if (valueAvailableQuantiy < item.Quantity) 
                    {
                        var category = await _unitOfWork._categoryRepository.GetById(product.IdCategory);
                        throw new Exception($"The quantity of category {category.Name} is over required number"); 
                    }
                    ;
            }
            List <Product> products = new List<Product>();
            // Tính toán 
            if (customerPackage.Items != null)
                foreach (var item in customerPackage.Items)
                {
                    var product = await _unitOfWork._productRepository.GetById(item.ProductId);
                    item.Status = 0;
                    item.Deposit = product.Deposit;
                    item.TornMoney = 0;
                    product.Quantity-=item.Quantity;
                    customerPackage.TotalDeposit += product.Price * item.Quantity;
                    products.Add(product);
                }
            if (wallet.WalletName == "Outfit4rent" && user.MoneyInWallet < (double)(customerPackage.Price + customerPackage.TotalDeposit)) throw new Exception("User doesn't have enough money to check-out.");
            var deposite = new Deposit()
            {
                CustomerId = customerPackage.CustomerId,
                AmountMoney = (double)(customerPackage.Price + customerPackage.TotalDeposit),
                Date = DateTime.Now,
                Type = "Payment for rent"

            };
            await _unitOfWork.BenginTransaction();
            await _unitOfWork.CommitTransaction();
            try
            {
                var createdDeposit = await _unitOfWork._depositRepository.CreateDeposit(deposite);
                var createdTransaction = await _unitOfWork._transactionRepository.CreateTransaction(new Transaction()
                {
                   Amount=createdDeposit.AmountMoney,
                   DateTransaction=DateTime.Now,
                   DepositId=createdDeposit.Id,
                   Paymethod=wallet.WalletName,
                   WalletId=wallet.Id,
                   Status=0,
                });
                customerPackage.TransactionId = createdTransaction.Id;
                var result = await _unitOfWork._customerPackageRepository.CreateUserPackage(customerPackage);
                if(result != null) 
                { 
                 foreach(var product in products)
                    {
                        await _unitOfWork._productRepository.UpdateProduct(product);
                    }
                    if (wallet.WalletName == "Outfit4rent") 
                    {
                        user.MoneyInWallet -= (long)(customerPackage.Price + customerPackage.TotalDeposit);
                        await _unitOfWork._customerRepository.UpdateCustomer(user);
                    }

                }
                return _mapper.Map<CustomerPackageModel>(result);
            }
            catch(Exception ex)
            {
                await _unitOfWork.RollbackTransaction();
                throw new Exception(ex.Message);
               
            }
            
        }

        public async Task<List<CustomerPackageModel>> GetAllCustomerPackageByCustomerId(int customerId)
        {
            var result = await _unitOfWork._customerPackageRepository.GetCustomerPackageByCustomerId(customerId);
            return _mapper.Map<List<CustomerPackageModel>>(result);
        }

        public async Task<CustomerPackageModel> GetPackagebyId(int packageid)
        {
           var result = await _unitOfWork._customerPackageRepository.GetCustomerPackageById(packageid);
            return _mapper.Map < CustomerPackageModel > (result);
        }   
    }


}
