
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.PartnerService
{
    public interface IPartnerService
    {
       public Task<List<PartnerModel>> GetAllPartners();
       public Task<PartnerModel> GetPartnerById(int id);
        public Task<PartnerModel> CreatePartner(PartnerModel createPartnerRequestDTO);
        public Task<PartnerModel> UpdatePartner(PartnerModel updatePartnerRequestDTO);
        public Task<PartnerModel> ChangeStatus(int partnerId, int status);
    }
}
