using AutoMapper;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.ItemInUserPackage;
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
                var result = new List<ItemInUserPackageDto>();
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
    }
}
