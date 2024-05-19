using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SWD392.OutfitBox.API.Controllers.Endpoints
{
  
    public static class ReviewEndpoints 
    {
        public const string ActiveOrDeactiveReview = "reviews/active-or-deactive/{id}";
        public const string GetAllEnabledReviews = "reviews/enabled";
        public const string GetAllEnabledReviewsByCustomerId = "reviews/enabled/by-customer-id/{customerId}";
        public const string CreateReview = "reviews";
        public const string GetReviewById = "reviews/{id}";
        public const string DeleteReviewById = "reviews/{id}";

    }
}
