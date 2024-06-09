using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Repositories
{
    public class PartnerRepository : BaseRepository<Partner>, IPartnerRepository
    {
        public PartnerRepository(Context context) : base(context)
        {
        }

        public async Task<Partner> CreatePartner(Partner entity)
        {
            var result = await this.AddAsync(entity);
            await this.SaveChangesAsync();
            return await this.Get().OrderBy(x=>x.Id).LastAsync();
        }

        public async Task<List<Partner>> GetAllPartners()
        {
            return await this.Get().ToListAsync();
        }

        public async Task<Partner> GetPartnerById(int id)
        {
            return await this.Get().FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Partner> UpdatePartner(Partner entity)
        {
             this.Update(entity);
            await this.SaveChangesAsync();
            return await this.Get().FirstAsync(x => x.Id == entity.Id);
        }
    }
}
