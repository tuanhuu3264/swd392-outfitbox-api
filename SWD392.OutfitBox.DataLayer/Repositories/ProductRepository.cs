using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace SWD392.OutfitBox.DataLayer.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        internal Context _context;
      

        public ProductRepository(Context context) : base(context)
        {
            _context = context;

        }

        public async Task<List<Product>> GetAll()
        {   
           
            return await this.Get().Include(x => x.Images).Include(x => x.Brand).Include(x => x.Category).ToListAsync();

        }

        public async Task<Product> CreateProduct(Product product)
        {
            var result = await this.AddAsync(product);
            return result;
        }

        public async Task<Product> GetById(int id)
        {   
            
                var result = await this.Get().Include(x => x.Images).Include(x => x.Brand).Include(x => x.Category).FirstOrDefaultAsync(x => x.ID == id);
                if (result == null) return null;
                return result;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
           await this.Update(product);
           await this.SaveChangesAsync();
           return await this.GetById(product.ID);
        }

        public async Task<Product> DeleteProduct(int id)
        {
            return null;
        }

        public async Task<Product> GetDetail(int id)
        {
          return await this.Get().Include(x=>x.Images).FirstOrDefaultAsync(x => x.ID == id);
        }
    }
}
