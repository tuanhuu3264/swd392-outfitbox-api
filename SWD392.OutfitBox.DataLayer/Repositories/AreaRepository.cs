using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.Core.RepoInterfaces;
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
    public class AreaRepository : BaseRepository<Area>, IAreaRepository
    {
        public AreaRepository(Context context) : base(context)
        {
        }

        public async Task<Area> CreateArea(Area addedArea)
        {
            await this.AddAsync(addedArea);
            await this.SaveChangesAsync();
            return await this.Get().OrderBy(x => x.Id).LastAsync();
        }

        public async Task<List<Area>> GetAllArea()
        {
            return await this.Get().ToListAsync();
        }

        public async Task<Area> GetById(int id)
        {
            return await this.Get().FirstOrDefaultAsync(x=>x.Id== id);
        }

        public async Task<Area> UpdateArea(Area updatedArea)
        {
            this.Update(updatedArea);
            await this.SaveChangesAsync();
            return await this.Get().FirstAsync(x=>x.Id==updatedArea.Id);
        }
    }
}
