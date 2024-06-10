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

namespace SWD392.OutfitBox.DataLayer.Repositories
{
    public class ReviewImageRepository : BaseRepository<ReviewImage>, IReviewImageRepository
    {
        public ReviewImageRepository(Context context) : base(context)
        {
        }

        public async Task<ReviewImage> CreateReviewImage(ReviewImage image)
        {
            await this.AddAsync(image);
            await this.SaveChangesAsync();
            return await this.Get().OrderBy(x => x.Id).LastAsync();
        }

        public async Task<bool> DeleteReviewImageByReviewId(int reviewId)
        {
            var reviewImages  = await this.Get().Where(x=>x.ReviewId==reviewId).ToListAsync();
            this.DeleteRange(reviewImages.ToArray());
            await this.SaveChangesAsync();
            return true;
        }
    }
}
