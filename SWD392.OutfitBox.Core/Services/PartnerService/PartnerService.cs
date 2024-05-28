using AutoMapper;
using SWD392.OutfitBox.Core.Models.Requests.Partner;
using SWD392.OutfitBox.Core.Models.Responses.Partner;
using SWD392.OutfitBox.Core.UnitOfWork;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.PartnerService
{
    public class PartnerService : IPartnerService
    {   
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PartnerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PartnerDTO> ChangeStatus(int partnerId, int status)
        {
            var checkingPartner = await _unitOfWork.GetPartnerRepository().GetPartnerById(partnerId);
            if (checkingPartner == null) throw new Exception("There is not found the partner that has id: " + partnerId);
            checkingPartner.Status = status;
            var result = await _unitOfWork.GetPartnerRepository().UpdatePartner(checkingPartner);
            return _mapper.Map<PartnerDTO>(result);
        }

        public async Task<CreatePartnerResponseDTO> CreatePartner(CreatePartnerRequestDTO createPartnerRequestDTO)
        {
            var crearedPartner = _mapper.Map<Partner>(createPartnerRequestDTO);
            crearedPartner.Status = 1;
            var result = await _unitOfWork.GetPartnerRepository().CreatePartner(crearedPartner);
            return _mapper.Map<CreatePartnerResponseDTO>(result);
        }

        public async Task<List<PartnerDTO>> GetAllPartners()
        {
            var partners = await _unitOfWork.GetPartnerRepository().GetAllPartners();   
            return partners.Select(x=>_mapper.Map<PartnerDTO>(x)).ToList();
        }

        public async Task<PartnerDTO> GetPartnerById(int id)
        {
            var checkingPartner = await _unitOfWork.GetPartnerRepository().GetPartnerById(id);
            if (checkingPartner == null) throw new Exception("There is not found the partner that has id: " + id);
            return _mapper.Map<PartnerDTO>(checkingPartner);
        }

        public async Task<UpdatePartnerResponseDTO> UpdatePartner(UpdatePartnerRequestDTO updatePartnerRequestDTO)
        {
            var checkingPartner = await _unitOfWork.GetPartnerRepository().GetPartnerById(updatePartnerRequestDTO.Id);
            if (checkingPartner == null) throw new Exception("There is not found the partner that has id: " + updatePartnerRequestDTO.Id);
            checkingPartner.Name = updatePartnerRequestDTO.Name;
            checkingPartner.Phone = updatePartnerRequestDTO.Phone;
            checkingPartner.Status = checkingPartner.Status;
            checkingPartner.Address= updatePartnerRequestDTO.Address;
            checkingPartner.AreaId = updatePartnerRequestDTO.AreaId;
            checkingPartner.Password = checkingPartner.Password;
            var result = await _unitOfWork.GetPartnerRepository().UpdatePartner(checkingPartner);
            return _mapper.Map<UpdatePartnerResponseDTO>(result);
        }
    }
}
