using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Tnef;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Review;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Review;
using SWD392.OutfitBox.Core.Services.ReviewService;

namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class ReviewController : ControllerBase
    {
        public IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpPut(ReviewEndpoints.GetAllEnabledReviews)]
        public async Task<List<ReviewDTO>> GetAllEnabledReviews()
        {
            var result = await _reviewService.GetAllEnabledReviews();
            return result;
        }
        [HttpGet(ReviewEndpoints.GetAllEnabledReviewsByCustomerId)]
        public async Task<List<ReviewDTO>> GetAllEnabledReviewsByCustomerId([FromRoute]int customerId)
        {
            var result = await _reviewService.GetAllEnabledReviewsByCustomerId(customerId);
            return result;
        }
        [HttpGet(ReviewEndpoints.GetReviewById)]
        public async Task<ReviewDTO> GetReviewById(int id)
        {
            var result = await _reviewService.GetReviewById(id);
            return result;
        }
        [HttpPost(ReviewEndpoints.CreateReview)]
        public async Task<CreateReviewResponseDTO> CreateReview([FromBody] CreateReviewRequestDTO request)
        {
            var result = await _reviewService.CreateReview(request);
            return result;
        }
        [HttpDelete(ReviewEndpoints.DeleteReviewById)]
        public async Task<DeleteReviewResponseDTO> DeleteReviewById([FromRoute] int id)
        {
            var result = await _reviewService.DeleteReviewById(id);
            return result;
        }
    }
}
