using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.RepoInterfaces
{
    public interface IReviewRepository
    {
        public Task<List<Review>> GetAllEnabledReviews();
        public Task<List<Review>> GetAllEnabledReviewsByCustomerId(int customerId);
        public Task<Review> CreateReview(Review review);
        public Task<Review> ActiveOrDeactiveReview(int id);
        public Task<bool> DeleteReviewById(int id);
        public Task<Review> GetReviewById(int id);
    }
}
