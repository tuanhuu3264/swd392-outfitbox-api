using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Domain.Entities;
using SWD392.OutfitBox.Infrastructure.Databases.SQLServer;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SWD392.OutfitBox.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(Context context) : base(context)
        {
        
        }

        public async Task<List<Product>> GetAll()
        {
            return await this.Get().Include(x => x.Images).Include(x => x.Brand).Include(x => x.Category).ToListAsync();
        }

        public async Task<Product> CreateProduct(Product product)
        {
            var result = await this.AddAsync(product);
            await this.SaveChangesAsync();
            return result;
        }

        public async Task<Product> GetById(int id)
        {
            var result = await this.Get().Include(x => x.Images).FirstOrDefaultAsync(x => x.ID == id);
            if (result == null) return new Product();
            return result;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await this.GetById(product.ID);
            return result;
        }
    }
}
