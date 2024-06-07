using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Interfaces
{
    public interface IPartnerRepository
    {
        public Task<Partner> GetPartnerById(int id);    
        public Task<List<Partner>> GetAllPartners();
        public Task<Partner> CreatePartner(Partner entity);
        public Task<Partner> UpdatePartner(Partner entity);
        
    }
}
