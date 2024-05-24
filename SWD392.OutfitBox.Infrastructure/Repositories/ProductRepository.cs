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
        internal Context _context;
        internal IImageRepository _imageRepository;
        public ProductRepository(Context context, IImageRepository imageRepository) : base(context)
        {
            _context = context;
            _imageRepository = imageRepository;
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

        public async Task<bool> UpdateProduct(Product product)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {

                var existingProduct = await this.GetById(product.ID);
                if (existingProduct == null)
                {
                    await transaction.RollbackAsync();
                    return false;
                }
                var removedImages = existingProduct.Images
               .Where(img => !product.Images.Any(updatedImg => updatedImg.ID == img.ID))
               .ToList();
                foreach (var removedImage in removedImages)
                {
                    existingProduct.Images.Remove(removedImage);
                }
                var newImages = product.Images
               .Where(updatedImg => !existingProduct.Images.Any(img => img.ID == updatedImg.ID))
               .ToList();
                foreach (var newImage in newImages)
                {
                    existingProduct.Images.Add(newImage);
                }
                return true;
            }
        }
       }
}
