using AutoMapper;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.PartnerService
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

        public async Task<PartnerModel> ChangeStatus(int partnerId, int status)
        {
            var checkingPartner = await _unitOfWork._partnerRepository.GetPartnerById(partnerId);
            if (checkingPartner == null) throw new Exception("There is not found the partner that has id: " + partnerId);
            checkingPartner.Status = status;
            var result = await _unitOfWork._partnerRepository.UpdatePartner(checkingPartner);
            return _mapper.Map<PartnerModel>(result);
        }

        public async Task<PartnerModel> CreatePartner(PartnerModel createPartnerRequestDTO)
        {
            var crearedPartner = _mapper.Map<Partner>(createPartnerRequestDTO);
            crearedPartner.Status = 1;
            var result = await _unitOfWork._partnerRepository.CreatePartner(crearedPartner);
            return _mapper.Map<PartnerModel>(result);
        }

        public async Task<List<PartnerModel>> GetAllPartners()
        {
            var partners = await _unitOfWork._partnerRepository.GetAllPartners();   
            return partners.Select(x=>_mapper.Map<PartnerModel>(x)).ToList();
        }

        public async Task<PartnerModel> GetPartnerById(int id)
        {
            var checkingPartner = await _unitOfWork._partnerRepository.GetPartnerById(id);
            if (checkingPartner == null) throw new Exception("There is not found the partner that has id: " + id);
            return _mapper.Map<PartnerModel>(checkingPartner);
        }

        public async Task<PartnerModel> UpdatePartner(PartnerModel updatePartnerRequestDTO)
        {
            var checkingPartner = await _unitOfWork._partnerRepository.GetPartnerById(updatePartnerRequestDTO.Id.Value);
            if (checkingPartner == null) throw new Exception("There is not found the partner that has id: " + updatePartnerRequestDTO.Id);
            _mapper.Map(updatePartnerRequestDTO,checkingPartner);
            var result = await _unitOfWork._partnerRepository.UpdatePartner(checkingPartner);
            return _mapper.Map<PartnerModel>(result);
        }
    }
}
