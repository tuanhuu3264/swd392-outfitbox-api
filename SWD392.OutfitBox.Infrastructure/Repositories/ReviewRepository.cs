using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Domain.Entities;
using SWD392.OutfitBox.Infrastructure.Databases.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Infrastructure.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(Context context) : base(context)
        {
        }

        public async Task<Review> ActiveOrDeactiveReview(int id)
        {
            var result = await this.GetReviewById(id);
            result.Status = 1 - result.Status;
            this.Update(result);
            await this.SaveChangesAsync();
            return result;

        }

        public async Task<Review> CreateReview(Review review)
        {
            var result = await this.AddAsync(review);
            await this.SaveChangesAsync(); 
            return await this.Get().OrderBy(x=>x.Id).LastAsync();
        }

        public async Task<bool> DeleteReviewById(int id)
        {
            var result = await this.GetReviewById(id);
            this.Delete(result);
            await this.SaveChangesAsync();
            return true;
        }

        public async Task<List<Review>> GetAllEnabledReviews()
        {
            return await this.Get().Include(x=>x.ReviewImages).Where(x=>x.Status == 1).ToListAsync();
        }

        public async Task<List<Review>> GetAllEnabledReviewsByCustomerId(int customerId)
        {
            return await this.Get().Include(x => x.ReviewImages).Where(x => x.Status == 1 && x.CustomerId==customerId).ToListAsync();
        }

        public async Task<Review> GetReviewById(int id)
        {
            var result = await this.Get().Include(x=>x.ReviewImages).Where(x=>x.Id==id).FirstOrDefaultAsync();
            return result == null ? new Review() : result;  
        }
    }
}
