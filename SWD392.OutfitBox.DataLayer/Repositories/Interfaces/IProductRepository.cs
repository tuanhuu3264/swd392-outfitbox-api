using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> CreateProduct(Product product);
        Task<Product> GetById(int id);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(int id);
        Task<Product> GetDetail(int id);
    }
}
