using Abp.Application.Services.Dto;
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
        public async Task<CustomerPackageModel> ChangeStatus(int id, int status)
        {
            using (var transaction = _unitOfWork.BenginTransaction())
            {
                try
                {
                    var customerPackageModel = await _unitOfWork._customerPackageRepository.GetCustomerPackgageAndItemsbyId(id);
                    if (customerPackageModel == null) throw new Exception("Not Found this CustomerPackage");
                    if (customerPackageModel.Status == status) throw new Exception("This CustomerPackage already has this status");

                    var itemInCustomerPackageModel = await _unitOfWork._itemsInUserPackageRepository.GetByUserPackageId(customerPackageModel.Id);

                    //-1 - canceled order
                    // 0 - pending approval
                    // 1 - renting
                    // 2 - rental expired

                    if (customerPackageModel.Status == 0 && status == 1)
                    {
                        customerPackageModel.Status = status;
                        itemInCustomerPackageModel.ForEach(x => x.Status = 1);

                        foreach (var item in itemInCustomerPackageModel)
                        {
                            await _unitOfWork._itemsInUserPackageRepository.UpdateItem(item);
                        }

                        var updatedOrder = await _unitOfWork._customerPackageRepository.SaveAsyn(customerPackageModel);

                        await _unitOfWork.SaveChangesAsync();
                        await _unitOfWork.CommitTransaction();

                        return _mapper.Map<CustomerPackageModel>(updatedOrder);
                    }
                    else if (customerPackageModel.Status == 0 && status == -1)
                    {
                        if (customerPackageModel.Items != null)
                        {
                            foreach (var item in customerPackageModel.Items)
                            {
                                var product = await _unitOfWork._productRepository.GetById(item.ProductId);
                                if (product != null)
                                {
                                    product.Quantity += item.Quantity;
                                    await _unitOfWork._productRepository.UpdateProduct(product);
                                }
                            }
                        }

                        customerPackageModel.Status = status;
                        itemInCustomerPackageModel.ForEach(x => x.Status = -1);

                        var updatedOrder = await _unitOfWork._customerPackageRepository.SaveAsyn(customerPackageModel);

                        var customer = await _unitOfWork._customerRepository.GetCustomerById(customerPackageModel.CustomerId);
                        if (customer != null)
                        {
                            customer.MoneyInWallet += (long)(customerPackageModel.TotalDeposit + customerPackageModel.Price);
                            await _unitOfWork._customerRepository.UpdateCustomer(customer);
                        }

                        await _unitOfWork.SaveChangesAsync();
                        await _unitOfWork.CommitTransaction();

                        return _mapper.Map<CustomerPackageModel>(updatedOrder);
                    }
                    else
                    {
                        throw new Exception("Invalid status transition");
                    }
                }
                catch (Exception ex)
                {
                    await _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
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

            // Check tổng số lượng sản phẩm phải nhỏ hơn tổng số lượng quy định 
            var numberProducts = customerPackageModel.ItemInUsers.Sum(x => x.Quantity);
            if (numberProducts > package.NumOfProduct) throw new Exception("Number of products is over required number");

            // Check số lượng sản phẩm có phù hợp không
            if (customerPackage.Items != null)
            {
                foreach (var item in customerPackage.Items)
                {
                    var product = await _unitOfWork._productRepository.GetById(item.ProductId);
                    if (product == null) throw new Exception($"Product with ID {item.ProductId} not found.");
                    if (item.Quantity > product.Quantity) throw new Exception($"The quantity of product {product.Name} is over available number");
                }
            }

            // Check số lượng category có phù hợp không 
            var categoryPackages = await _unitOfWork._categoryPackageRepository.GetAllCategoryPackagesByPackageId(package.Id);
            var categoryPackage = categoryPackages.ToDictionary(cp => cp.Id, cp => cp.MaxAvailableQuantity);

            if (customerPackage.Items != null)
            {
                foreach (var item in customerPackage.Items)
                {
                    var product = await _unitOfWork._productRepository.GetById(item.ProductId);
                    if (product == null) throw new Exception($"Product with ID {item.ProductId} not found.");

                    if (!categoryPackage.TryGetValue(product.IdCategory, out var maxQuantity))
                    {
                        throw new Exception($"Category with ID {product.IdCategory} is not required in package");
                    }

                    if (maxQuantity < item.Quantity)
                    {
                        var category = await _unitOfWork._categoryRepository.GetById(product.IdCategory);
                        if (category == null) throw new Exception($"Category with ID {product.IdCategory} not found.");
                        throw new Exception($"The quantity of category {category.Name} is over required number");
                    }
                }
            }

            List<Product> products = new List<Product>();
            // Tính toán 
            if (customerPackage.Items != null)
            {
                foreach (var item in customerPackage.Items)
                {
                    var product = await _unitOfWork._productRepository.GetById(item.ProductId);
                    if (product == null) throw new Exception($"Product with ID {item.ProductId} not found.");

                    item.Status = 0;
                    item.Deposit = product.Deposit;
                    item.TornMoney = 0;
                    product.Quantity -= item.Quantity;
                    customerPackage.TotalDeposit += product.Price * item.Quantity;
                    products.Add(product);
                }
            }

            if (wallet.WalletName == "Outfit4rent" && user.MoneyInWallet < (double)(customerPackage.Price + customerPackage.TotalDeposit))
                throw new Exception("User doesn't have enough money to check-out.");

            var deposite = new Deposit()
            {
                CustomerId = customerPackage.CustomerId,
                AmountMoney = (double)(customerPackage.Price + customerPackage.TotalDeposit),
                Date = DateTime.Now,
                Type = "Payment for rent"
            };

            using (var transaction = _unitOfWork.BenginTransaction())
            {
                try
                {
                    var createdDeposit = await _unitOfWork._depositRepository.CreateDeposit(deposite);
                    var createdTransaction = await _unitOfWork._transactionRepository.CreateTransaction(new Transaction()
                    {
                        Amount = createdDeposit.AmountMoney,
                        DateTransaction = DateTime.Now,
                        DepositId = createdDeposit.Id,
                        Paymethod = wallet.WalletName,
                        WalletId = wallet.Id,
                        Status = 0,
                    });

                    customerPackage.TransactionId = createdTransaction.Id;
                    customerPackage.QuantityOfItems = customerPackageModel.ItemInUsers.Sum(x => x.Quantity);
                    var result = await _unitOfWork._customerPackageRepository.CreateUserPackage(customerPackage);

                    if (result != null)
                    {
                        foreach (var product in products)
                        {
                            await _unitOfWork._productRepository.UpdateProduct(product);
                        }

                        if (wallet.WalletName == "Outfit4rent")
                        {
                            user.MoneyInWallet -= (long)(customerPackage.Price + customerPackage.TotalDeposit);
                            await _unitOfWork._customerRepository.UpdateCustomer(user);
                        }
                    }

                    await _unitOfWork.CommitTransaction();
                    return _mapper.Map<CustomerPackageModel>(result);
                }
                catch (Exception ex)
                {
                    await _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<List<CustomerPackageModel>> GetAllCustomerPackageByCustomerId(int customerId)
        {
            var result = await _unitOfWork._customerPackageRepository.GetCustomerPackageByCustomerId(customerId);
            return _mapper.Map<List<CustomerPackageModel>>(result);
        }

        public async Task<List<CustomerPackageModel>> GetCustomrPackagesByStatus(int status)
        {   
            var result = await _unitOfWork._customerPackageRepository.GetCustomerPackageByStatus(status);
            return _mapper.Map<List<CustomerPackageModel>>(result);
        }

        public async Task<CustomerPackageModel> GetPackagebyId(int packageid)
        {
           var result = await _unitOfWork._customerPackageRepository.GetCustomerPackageById(packageid);
            return _mapper.Map <CustomerPackageModel > (result);
        }   
    }


}
