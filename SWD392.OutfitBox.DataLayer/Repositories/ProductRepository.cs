using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System.Reflection.Metadata.Ecma335;
using System.Linq.Expressions;
using Abp.Linq.Expressions;
using System.Globalization;

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
            return await this.Get().Include(x => x.Images).FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<List<Product>> GetList(int? pageIndex = null, int? pageSize = null, string sorted = "", string orders = "", string name = "", List<int>? idBrand = null, List<int>? idCategory = null, int? status = null, double? maxMoney = null, double? minMoney = null)
        {
            var predicate = PredicateBuilder.New<Product>();

            predicate.And(x => true);
            if (!string.IsNullOrEmpty(name.Trim()))
            {
                predicate = predicate.And(x => x.Name.ToLower().Contains(name.ToLower()));
            }
            if (idBrand != null)
            {
                var sub = PredicateBuilder.New<Product>();
                foreach (var item in idBrand)
                {
                    sub = sub.Or(x => x.IdBrand == item);
                }
                predicate = predicate.And(sub);
            }
            if (idCategory != null)
            {
                var sub = PredicateBuilder.New<Product>();
                foreach (var item in idCategory)
                {
                    sub = sub.Or(x => x.IdCategory == item);
                }
                predicate = predicate.And(sub);
            }
            if (maxMoney.HasValue)
            {
                predicate = predicate.And(x => x.Deposit <= maxMoney.Value);
            }
            if (minMoney.HasValue)
            {
                predicate = predicate.And(x => x.Deposit >= minMoney.Value);
            }
            if (status.HasValue)
            {
                predicate = predicate.And(x => x.Status == status.Value);
            }

            Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null;
            if (!string.IsNullOrEmpty(orders) && !string.IsNullOrEmpty(sorted))
            {
                orderBy = (query) =>
                {

                    if (orders.ToLower().Equals("desc"))
                    {
                        query = query.OrderByDescending(x => EF.Property<Product>(x, sorted));
                    }
                    else
                    {
                        query = query.OrderBy(x => EF.Property<Product>(x, sorted));
                    }
                    return (IOrderedQueryable<Product>)query;

                };
            }

            var result= (await this.Get(predicate, orderBy, x=>x.Include("Brand").Include("Category").Include("Images"), pageIndex, pageSize)).ToList();
            return result;

            
        }
        public async Task<List<Product>> GetStartEnd(int? started = null, int? ended = null,
                                                     string sorted = "", string orders = "", string name = "",
                                                     List<int>? idBrand = null, List<int>? idCategory = null,
                                                     int? status = null,
                                                     double? maxMoney = null,
                                                     double? minMoney = null)
        {
            var predicate = PredicateBuilder.New<Product>();

            if (!string.IsNullOrEmpty(name))
            {
                predicate = predicate.And(x => x.Name.ToLower().Contains(name.ToLower()));
            }
            if (idBrand != null)
            {
                var sub = PredicateBuilder.New<Product>();
                foreach (var item in idBrand)
                {
                    sub = sub.Or(x => x.IdBrand == item);
                }
                predicate = predicate.And(sub);
            }
            if (idCategory != null)
            {
                var sub = PredicateBuilder.New<Product>();
                foreach (var item in idCategory)
                {
                    sub = sub.Or(x => x.IdCategory == item);
                }
                predicate = predicate.And(sub);
            }
            if (maxMoney.HasValue)
            {
                predicate = predicate.And(x => x.Deposit <= maxMoney.Value);
            }
            if (minMoney.HasValue)
            {
                predicate = predicate.And(x => x.Deposit >= minMoney.Value);
            }
            if (status.HasValue)
            {
                predicate = predicate.And(x => x.Status == status.Value);
            }
            else
            {
                predicate = predicate.And(x => true);
            }
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null;
            if (!string.IsNullOrEmpty(orders.Trim()) && !string.IsNullOrEmpty(sorted.Trim()))
            {
                orderBy = (query) =>
                {

                    if (orders.ToLower().Equals("desc"))
                    {
                        query = query.OrderByDescending(x => EF.Property<Product>(x, textInfo.ToTitleCase(sorted)));
                    }
                    else
                    {
                        query = query.OrderBy(x => EF.Property<Product>(x, textInfo.ToTitleCase(sorted)));
                    }
                    return (IOrderedQueryable<Product>)query;

                };
            }
            return (await this.GetStartEnd(predicate, orderBy, x => x.Include("Brand").Include("Category").Include("Images"), started, ended)).ToList();

        }
        
    }
}
