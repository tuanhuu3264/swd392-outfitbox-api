using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetTopologySuite.Index.HPRtree;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.ItemInUserPackage;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.ItemInUserPackage;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.ItemInUserPackageService
{
    public class ItemsInUserPackageService:IItemsInUserPackageService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;
        public ItemsInUserPackageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
        }
        public async Task<List<ItemInUserPackageDto>> GetAll()
        {
                var list = await _unitOfWork._itemsInUserPackageRepository.GetAllItemInPacket();
                if (list.Count == 0) throw new Exception("ListNull");
                var listItem = _mapper.Map<List<ItemInUserPackageDto>>(list);
                return listItem;        
        }
        public async Task<ItemInUserPackageDto> CreateItem(CreatedItemInPackage itemInPackage)
        {
                var item = _mapper.Map<ItemInUserPackage>(itemInPackage);
                var obj = await _unitOfWork._itemsInUserPackageRepository.CreateItemInUserPackage(item);
                var data = _mapper.Map<ItemInUserPackageDto>(obj);
                return data;
        }
        public async Task<ItemInUserPackageDto> UpdateItem(UpdateItemInPackage updateItemInPackage)
        {

            var obj = await _unitOfWork._itemsInUserPackageRepository.GetById(updateItemInPackage.Id);
            _mapper.Map(updateItemInPackage, obj);
            var flag = await _unitOfWork._itemsInUserPackageRepository.UpdateItem(obj);
            var data = _mapper.Map<ItemInUserPackageDto>(flag);
            return data;
        }
        public async Task<bool> DeleteItem(int itemid)
        {
            var item = await _unitOfWork._itemsInUserPackageRepository.GetById(itemid);
            if (item == null) throw new ArgumentException("Can not find this item");
            var obj = await _unitOfWork._itemsInUserPackageRepository.DeleteItem(itemid);
            return obj;
        }
    }
}
