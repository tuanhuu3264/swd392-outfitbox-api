using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Domain.Entities;
using SWD392.OutfitBox.Infrastructure.Databases.SQLServer;
using System.Threading.Tasks;
using System.Collections.Generic;
using SWD392.OutfitBox.Infrastructure.Databases.Redis;

namespace SWD392.OutfitBox.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        internal Context _context;
        internal IImageRepository _imageRepository;
        internal ICacheUnit<Product> _cacheUnit;
        public ProductRepository(Context context, IImageRepository imageRepository, ICacheUnit<Product> cacheUnit) : base(context)
        {
            _context = context;
            _imageRepository = imageRepository;
            _cacheUnit = cacheUnit;
        }

        public async Task<List<Product>> GetAll()
        {   
            var productsInCaching = await _cacheUnit.GetAll();
            if(productsInCaching == null)
            return await this.Get().Include(x => x.Images).Include(x => x.Brand).Include(x => x.Category).ToListAsync();
            return productsInCaching;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            var result = await this.AddAsync(product);
            return result;
        }

        public async Task<Product> GetById(int id)
        {   
            var productInCaching = await _cacheUnit.Get(typeof(Product), id);
            if (productInCaching == null)
            {
                var result = await this.Get().Include(x => x.Images).Include(x => x.Brand).Include(x => x.Category).FirstOrDefaultAsync(x => x.ID == id);
                if (result == null) return null;
                return result;
            }
            return productInCaching;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var obj = this.Update(product);
            await this.SaveChangesAsync();
            return obj == null;
        }
       }
}
