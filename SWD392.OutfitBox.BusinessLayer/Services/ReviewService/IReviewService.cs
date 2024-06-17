﻿
using SWD392.OutfitBox.BusinessLayer.BusinessModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.ReviewService
{
    public interface IReviewService 
    {
       public Task<List<ReviewModel>> GetAllEnabledReviews();
       public Task<List<ReviewModel>> GetAllEnabledReviewsByCustomerId (int customerId);
       public Task<ReviewModel> CreateReview(ReviewModel requestDTO);
       public Task<ReviewModel> ActiveOrDeactiveReviewById(int id);
        public Task<ReviewModel> GetReviewById (int id);
        public Task<bool> DeleteReviewById(int id);
    }
}
