using AutoMapper;
using SWD392.OutfitBox.Core.Constants;
using SWD392.OutfitBox.Core.Models.Requests.ItemInUserPackage;
using SWD392.OutfitBox.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.ItemInUserPackage
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
                var listItem = _mapper.Map<List<ItemInUserPackageDto>>(list);
                result.Data = listItem;
                result.Message = "ListItem";
                result.StatusCode = HttpStatusCode.OK;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.StatusCode = HttpStatusCode.NotFound;
                result.Data = null;
                return result;
            }
        }
    }
}
