
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Partner;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Partner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.PartnerService
{
    public interface IPartnerService
    {
       public Task<List<PartnerDTO>> GetAllPartners();
       public Task<PartnerDTO> GetPartnerById(int id);
        public Task<CreatePartnerResponseDTO> CreatePartner(CreatePartnerRequestDTO createPartnerRequestDTO);
        public Task<UpdatePartnerResponseDTO> UpdatePartner(UpdatePartnerRequestDTO updatePartnerRequestDTO);
        public Task<PartnerDTO> ChangeStatus(int partnerId, int status);
    }
}
