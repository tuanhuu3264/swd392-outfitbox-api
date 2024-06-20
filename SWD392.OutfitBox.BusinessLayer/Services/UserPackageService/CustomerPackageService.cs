using Abp.Domain.Uow;
using AutoMapper;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
