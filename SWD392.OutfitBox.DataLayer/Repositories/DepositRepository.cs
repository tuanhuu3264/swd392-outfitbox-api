using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Repositories
{
    public class DepositRepository : BaseRepository<Deposit>, IDepositRepository
    {
        public DepositRepository(Context context) : base(context)
        {
        }
        public async Task<Deposit> CreateDeposit(Deposit deposit)
        {
            await this.AddAsync(deposit);
            await this.SaveChangesAsync();
            return await this.Get().OrderBy(x => x.Id).LastAsync();
        }
    }
}
