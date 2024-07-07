using Abp.Domain.Uow;
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
     public async Task<CustomerPackageModel> CreateCustomerPackage(CustomerPackageModel customerPackageModel)
        {
            var customerPackage = _mapper.Map<CustomerPackage>(customerPackageModel);
            var package = await _unitOfWork._packageRepository.GetPackageById(customerPackage.PackageId);
            var user = await _unitOfWork._customerRepository.GetCustomerById(customerPackage.CustomerId);
            customerPackage.PackageName = package.Name;
            customerPackage.DateTo = customerPackage.DateFrom.AddDays(package.AvailableRentDays);
            customerPackage.Price = package.Price;
            customerPackage.ReceiverAddress = user.Address;
            customerPackage.ReceiverPhone = user.Phone;
            customerPackage.ReceiverName = user.Name;
            customerPackage.Status = 0;
            var count = package.NumOfProduct;
            var categorypackages = package.CategoryPackages;
            foreach (var quantityCategory in categorypackages)
            {

            }
            foreach (var item in customerPackage.Items)
            {
                var product = await _unitOfWork._productRepository.GetById(item.ProductId); 
                item.Status = 0;
                item.Deposit = product.Deposit;
                item.TornMoney = customerPackage.Price * item.Deposit;
                customerPackage.Price += item.TornMoney*item.Quantity;
                count = count - item.Quantity;
            }
            var result = await _unitOfWork._customerPackageRepository.CreateUserPackage(customerPackage);
            return _mapper.Map<CustomerPackageModel>(result);
        }
     public async Task<CustomerPackageModel> GetPackagebyId(int packageid)
        {
           var result = await _unitOfWork._customerPackageRepository.GetCustomerPackageById(packageid);
            return _mapper.Map < CustomerPackageModel > (result);
        }   
    }


}
