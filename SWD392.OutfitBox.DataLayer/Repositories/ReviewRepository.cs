using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SWD392.OutfitBox.DataLayer.Repositories
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
            await this.Update(result);
            await this.SaveChangesAsync();
            return result;

        }

        public async Task<Review> CreateReview(Review review)
        {
            var result = await this.AddAsync(review);
            await this.SaveChangesAsync(); 
            return await GetReviewById(review.Id);
        }

        public async Task<bool> DeleteReviewById(int id)
        {
            var result = await this.GetReviewById(id);
            await this.Delete(result);
            return true;
        }

        public async Task<List<Review>> GetAllEnabledReviews()
        {
            return await this.Get().Include(x=>x.ReviewImages).Include(x => x.User).Where(x=>x.Status == 1).ToListAsync();
        }

        public async Task<List<Review>> GetAllEnabledReviewsByCustomerId(int customerId)
        {
            return await this.Get().Include(x => x.ReviewImages).Include(x => x.User).Where(x => x.Status == 1 && x.CustomerId==customerId).ToListAsync();
        }

        public async Task<Review> GetReviewById(int id)
        {
            var result = await this.Get().Include(x=>x.ReviewImages).Include(x => x.User).Where(x=>x.Id==id).FirstOrDefaultAsync();
            return result;  
        }

        public async Task<List<Review>> GetReviewByPackageId(int id)
        {
            var result = await this.Get().Include(x => x.ReviewImages).Include(x => x.User).Where(x => x.PackageId == id).ToListAsync();
            return result;
        }

        public async Task<List<Review>> GetReviews()
        {
            var result = await this.Get().Include(x => x.ReviewImages).Include(x=>x.User).ToListAsync();
            return result;
        }
        public async Task<ReviewData> GetRatingbyPackageId(int id)
        {
            var result = new ReviewData();
            var rating = await this.Get().Where(x=>x.PackageId==id).GroupBy(x=>x.NumberStars).Select(x=> new RatingStar { StarNumber = x.Key,Quantity = x.Count()}).ToListAsync();
            result.PackageId = id;
            result.RatingStars = rating;
            return result;
        }
    }
}
