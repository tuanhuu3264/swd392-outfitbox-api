
using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Domain;
using SWD392.OutfitBox.Domain.Entities;
using SWD392.OutfitBox.Infrastructure.Databases.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Infrastructure.Repositories
{
    public class TypeRepository : BaseRepository<ProductType>, ITypeRepository
    {
        public TypeRepository(Context context) : base(context)
        {
        }

        public async Task<Domain.Entities.ProductType> CreateType(Domain.Entities.ProductType type)
        {
            var result = await this.AddAsync(type);
            await this.SaveChangesAsync();
            return result;
        }

        public async Task<List<ProductType>> GetAllTypes()
        {
            return await this.Get().ToListAsync();
        }

        public async Task<ProductType> GetById(int id)
        {
            var result = await this.Get().FirstOrDefaultAsync(x => x.ID == id);
            if (result == null) return new ProductType();
            return result;
        }

        public async Task<ProductType> UpdateType(ProductType type)
        {
            this.Update(type);
            await this.SaveChangesAsync();
            var result = await this.Get().FirstAsync(x => x.ID == type.ID);
            return result;
        }
    }
}
