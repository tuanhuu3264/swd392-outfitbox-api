using AutoMapper;
using SWD392.OutfitBox.Core.Constants;
using SWD392.OutfitBox.Core.Models.Requests.ItemInUserPackage;
using SWD392.OutfitBox.Core.UnitOfWork;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.ItemInUserPackageService
{
    public class ItemsInUserPackageService:IItemsInUserPackageService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;
        public ItemsInUserPackageService(IUnitOfWork unitOfWork)
        {
            {
                _unitOfWork = unitOfWork;
            }
        }
        public async Task<StatusCodeResponse<List<ItemInUserPackageDto>>> GetAll()
        {
            var result = new StatusCodeResponse<List<ItemInUserPackageDto>>();
            try
            {
                var list = await _unitOfWork.GetItemsInUserPackageRepository().Result.GetAllItemInPacket();
                if (list.Count == 0) throw new Exception("ListNull");
                var listItem = _mapper.Map<List<ItemInUserPackageDto>>(list);
                result.Data = listItem;
                result.Message = "ListItem";
                result.StatusCode = HttpStatusCode.OK;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.StatusCode = HttpStatusCode.InternalServerError;
                result.Data = null;
                return result;
            }
        }
        public async Task<StatusCodeResponse<ItemInUserPackageDto>> CreateItem(CreatedItemInPackage itemInPackage)
        {
            var result = new StatusCodeResponse<ItemInUserPackageDto>();
            try
            {
                var item = _mapper.Map<ItemInUserPackage>(itemInPackage);
                var obj = await _unitOfWork.GetItemsInUserPackageRepository().Result.CreateItemInUserPackage(item);
                var data = _mapper.Map<ItemInUserPackageDto>(obj);
                result.Data = data;
                result.Message = "Successful";
                result.StatusCode = HttpStatusCode.OK;
                return result;
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Message = ex.Message;
                result.StatusCode = HttpStatusCode.InternalServerError;
                return result;
            }
        }
    }
}
