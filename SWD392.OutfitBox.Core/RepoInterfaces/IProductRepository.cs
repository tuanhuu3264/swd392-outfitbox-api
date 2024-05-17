using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.RepoInterfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> CreateProduct(Product product);
    }
}
