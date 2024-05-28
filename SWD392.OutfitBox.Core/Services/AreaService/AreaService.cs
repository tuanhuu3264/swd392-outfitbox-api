using AutoMapper;
using SWD392.OutfitBox.Core.Models.Requests.Area;
using SWD392.OutfitBox.Core.Models.Responses.Area;
using SWD392.OutfitBox.Core.UnitOfWork;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.AreaService
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
            var result =  await (await _unitOfWork.GetAreaRepository()).CreateArea(addedArea);
            var returnArea = _mapper.Map<CreateAreaResponseDTO>(result);
            return returnArea;
        }

        public async Task<List<AreaDTO>> GetAllAreas()
        {
           var result = await (await _unitOfWork.GetAreaRepository()).GetAllArea();
           var returnAreas = result.Select(x=> _mapper.Map<AreaDTO>(x)).ToList().ToList();
           return returnAreas;
        }

        public async Task<UpdateAreaResponseDTO> UpdateArea(UpdateAreaRequestDTO updateAreaRequestDTO)
        {
            var checkingArea =await (await _unitOfWork.GetAreaRepository()).GetById(updateAreaRequestDTO.Id);
            if (checkingArea == null) throw new Exception("There is not found the area that has id: " + updateAreaRequestDTO.Id);
            checkingArea.Ward = updateAreaRequestDTO.Ward;
            checkingArea.Distrinct=updateAreaRequestDTO.Distrinct;
            checkingArea.City=updateAreaRequestDTO.City;
            var result = await (await _unitOfWork.GetAreaRepository()).UpdateArea(checkingArea);
            return _mapper.Map<UpdateAreaResponseDTO>(result);
        }
    }
}
