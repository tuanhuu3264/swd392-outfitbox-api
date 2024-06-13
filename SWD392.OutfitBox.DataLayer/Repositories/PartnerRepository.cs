using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Expressions;
using System.Globalization;

namespace SWD392.OutfitBox.DataLayer.Repositories
{
    public class PartnerRepository : BaseRepository<Partner>, IPartnerRepository
    {
        public PartnerRepository(Context context) : base(context)
        {
        }

        public async Task<Partner> CreatePartner(Partner entity)
        {
            var result = await this.AddAsync(entity);
            await this.SaveChangesAsync();
            return await this.Get().OrderBy(x=>x.Id).LastAsync();
        }

        public async Task<List<Partner>> GetAllPartners()
        {
            return await this.Get().ToListAsync();
        }

        public async Task<Partner> GetPartnerById(int id)
        {
            return await this.Get().FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Partner> UpdatePartner(Partner entity)
        {
           await this.Update(entity);
       
            return await this.Get().FirstAsync(x => x.Id == entity.Id);
        }
        public async Task<List<Partner>> GetPartners(int? pageIndex = null, int? pageSize = null, string? sorted=null, string? orders= null, string? email=null, string? phone = null, string? address =null, int? areaId = null, string? name = null, int? status = null)
        {
            var predicate = PredicateBuilder.New<Partner>();

            if (!string.IsNullOrEmpty(name))
            {
                predicate = predicate.And(x => x.Name.ToLower().Contains(name.ToLower()));
            }
            if (email != null)
            {
                predicate = predicate.And(x => x.Email.ToLower().Contains(email.ToLower()));
            }
            if (phone != null)
            {
                predicate = predicate.And(x => x.Phone.ToLower().Contains(phone.ToLower()));
            }
            if (status.HasValue)
            {
                predicate = predicate.And(x => x.Status == status.Value);
            }
            if (areaId.HasValue)
            {
                predicate = predicate.And(x => x.AreaId == areaId);
            }
            
            Func<IQueryable<Partner>, IOrderedQueryable<Partner>> orderBy = null;
            if (!string.IsNullOrEmpty(orders) && !string.IsNullOrEmpty(sorted))
            {
                orderBy = (query) =>
                {

                    if (orders.ToLower().Equals("desc"))
                    {
                        query = query.OrderByDescending(x => EF.Property<Partner>(x, sorted));
                    }
                    else
                    {
                        query = query.OrderBy(x => EF.Property<Partner>(x, sorted));
                    }
                    return (IOrderedQueryable<Partner>)query;

                };
            }
            return (await this.Get(predicate, orderBy, x => x.Include("ReturnOrders").Include("Area"), pageIndex, pageSize)).ToList();
        }
    }
}
