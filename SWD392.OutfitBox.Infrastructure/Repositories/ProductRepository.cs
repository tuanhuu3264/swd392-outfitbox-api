﻿using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Domain.Entities;
using SWD392.OutfitBox.Infrastructure.Databases.SQLServer;

namespace SWD392.OutfitBox.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>,IProductRepository
    {

        public ProductRepository(Context context) : base(context)
        {   

        }

        public async Task<List<Product>> GetAll()
        {
          return await this.Get().Include(x=>x.Brand).Include(x=>x.Category).ToListAsync();
        }
        public async Task<Product> Create(Product product)
        {
            var result = await this.AddAsync(product);
            await this.SaveChangesAsync();
            return result;
        }
    }
}
