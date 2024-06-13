using AutoMapper;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Area;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Area;
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
        public async Task<CreateAreaResponseDTO> CreateArea(CreateAreaRequestDTO createAreaRequestDTO)
        {
            var addedArea = _mapper.Map<Area>(createAreaRequestDTO);
            var result =  await _unitOfWork._areaRepository.CreateArea(addedArea);
            var returnArea = _mapper.Map<CreateAreaResponseDTO>(result);
            return returnArea;
        }

        public async Task<List<AreaDTO>> GetAllAreas()
        {
           var result = await _unitOfWork._areaRepository.GetAllArea();
           var returnAreas = result.Select(x=> _mapper.Map<AreaDTO>(x)).ToList().ToList();
           return returnAreas;
        }

        public async Task<UpdateAreaResponseDTO> UpdateArea(Area area)
        {
            var checkingArea =await _unitOfWork._areaRepository.GetById(area.Id);
            if (checkingArea == null) throw new ArgumentNullException("There is not found the area that has id: " + area.Id);
            checkingArea = _mapper.Map(area,checkingArea);
            var result = await _unitOfWork._areaRepository.UpdateArea(checkingArea);
            return _mapper.Map<UpdateAreaResponseDTO>(result);
        }

        
    }
}
