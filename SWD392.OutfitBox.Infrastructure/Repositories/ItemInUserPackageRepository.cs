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
    public class ItemInUserPackageRepository : BaseRepository<ItemInUserPackage>, IItemsInUserPackage
    {
        public ItemInUserPackageRepository(Context context) : base(context)
        {
        }

        public Task<List<ItemInUserPackage>> CreateItemsInUserPackage(ItemInUserPackage[] itemsInUserPackage)
        {
            throw new NotImplementedException();
        }
    }
}
