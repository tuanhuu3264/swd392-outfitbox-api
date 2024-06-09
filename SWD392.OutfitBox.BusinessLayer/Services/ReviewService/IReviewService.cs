
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Review;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.ReviewService
{
    public interface IReviewService 
    {
       public Task<List<ReviewDTO>> GetAllEnabledReviews();
       public Task<List<ReviewDTO>> GetAllEnabledReviewsByCustomerId (int customerId);
       public Task<CreateReviewResponseDTO> CreateReview(CreateReviewRequestDTO requestDTO);
       public Task<ReviewDTO> ActiveOrDeactiveReviewById(int id);
        public Task<ReviewDTO> GetReviewById (int id);
        public Task<DeleteReviewResponseDTO> DeleteReviewById(int id);
    }
}
