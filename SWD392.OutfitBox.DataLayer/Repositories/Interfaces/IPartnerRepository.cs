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
        public Task<List<Partner>> GetPartners(int? pageIndex = null, int? pageSize = null, string? sorted = null, string? orders = null, string? email = null, string? phone = null, string? address = null, int? areaId = null, string? name = null, int? status = null);


    }
}
