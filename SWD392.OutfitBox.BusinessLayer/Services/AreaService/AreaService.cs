using AutoMapper;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.AreaService
{
    public class AreaService : IAreaService
    {   
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AreaService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AreaModel> CreateArea(AreaModel createAreaRequestDTO)
        {
            var addedArea = _mapper.Map<Area>(createAreaRequestDTO);
            var result =  await _unitOfWork._areaRepository.CreateArea(addedArea);
            var returnArea = _mapper.Map<AreaModel>(result);
            return returnArea;
        }

        public async Task<List<AreaModel>> GetAllAreas()
        {
           var result = await _unitOfWork._areaRepository.GetAllArea();
           var returnAreas = result.Select(x=> _mapper.Map<AreaModel>(x)).ToList().ToList();
           return returnAreas;
        }

        public async Task<AreaModel> UpdateArea(AreaModel area)
        {
            if (area.Id.HasValue == false) throw new Exception("There is no id in request");

            var checkingArea =await _unitOfWork._areaRepository.GetById(area.Id.Value);

            if (checkingArea == null) throw new ArgumentNullException("There is not found the area that has id: " + area.Id);
            checkingArea.Address = area.Address != null ? area.Address.ToString() : checkingArea.Address;
            checkingArea.District = area.District != null ? area.District.ToString() : checkingArea.District;
            checkingArea.City = area.City != null ? area.City.ToString() : checkingArea.City;
            var result = await _unitOfWork._areaRepository.UpdateArea(checkingArea);
            return _mapper.Map<AreaModel>(result);
        }

        
    }
}
