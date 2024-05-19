using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Domain.Entities;
using SWD392.OutfitBox.Infrastructure.Databases.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Infrastructure.Repositories
{
    public class CustomerPackageRepository : BaseRepository<CustomerPackage>, ICustomerPackageRepository
    {
        public CustomerPackageRepository(Context context) : base(context)
        {
        }

        public async Task<CustomerPackage> CreateUserPackage(CustomerPackage userPackage)
        {
            var result = await this.AddAsync(userPackage);
            await this.SaveChangesAsync();
            return await this.Get().FirstAsync(x=>x.Id==userPackage.Id);
        }
    }
}
