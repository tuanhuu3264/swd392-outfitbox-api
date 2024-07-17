using AutoMapper;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.BusinessModels.AdminModel;

namespace SWD392.OutfitBox.BusinessLayer.Services.ReviewService
{
    public class ReviewService : IReviewService
    {
        public IReviewRepository _reviewRepository;
        public IMapper _mapper;
        public ReviewService(IMapper mapper, IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }
        public async Task<ReviewModel> ActiveOrDeactiveReviewById(int id)
        {
            var result = await _reviewRepository.ActiveOrDeactiveReview(id);
            return _mapper.Map<ReviewModel>(result);
        }

        public async Task<ReviewModel> CreateReview(ReviewModel requestDTO)
        {
            var review = _mapper.Map<Review>(requestDTO);
            review.Date = DateTime.Now;
            review.Status = 1;
            var result = await _reviewRepository.CreateReview(review);
            return _mapper.Map<ReviewModel>(result);
        }

        public async Task<bool> DeleteReviewById(int id)
        {
            var result = await _reviewRepository.DeleteReviewById(id);
            if (result == true) return true;
           return false;
        }

        public async Task<List<ReviewModel>> GetAllEnabledReviews()
        {
            return (await _reviewRepository.GetAllEnabledReviews()).Select(x => _mapper.Map<ReviewModel>(x)).ToList();
        }

        public async Task<List<ReviewModel>> GetAllEnabledReviewsByCustomerId(int customerId)
        {
            return (await _reviewRepository.GetAllEnabledReviewsByCustomerId(customerId)).Select(x => _mapper.Map<ReviewModel>(x)).ToList();
        }

        public async Task<List<ReviewModel>> GetAllReviews()
        {
            var result = await _reviewRepository.GetReviews();
            return _mapper.Map<List<ReviewModel>>(result);
        }

        public async Task<List<ReviewModel>> GetAllReviewsByPackageId(int packageId)
        {
            var result= await _reviewRepository.GetReviewByPackageId(packageId);
            return _mapper.Map<List<ReviewModel>>(result);
        }

        public async Task<ReviewModel> GetReviewById(int id)
        {
            var result = await _reviewRepository.GetReviewById(id);
            if (result == null){ throw new Exception("Not Found"); }
            return _mapper.Map<ReviewModel>(result);
        }
        public async Task<ReviewDataModel> GetReviewDataModelByPackageId(int packageId)
        {
            var list = await _reviewRepository.GetRatingbyPackageId(packageId);
            var result = _mapper.Map<ReviewDataModel>(list);
            result.QuantityOfReviews = result.RatingStars.Sum(x => x.Quantity) ;
            result.AverageStar = 0;
            var sum = 0;
            foreach ( var item in result.RatingStars) {
                item.Rate = (double)item.Quantity / result.QuantityOfReviews;
                sum = sum + item.StarNumber * item.Quantity;
            }
            result.AverageStar = (double)sum / result.QuantityOfReviews;
            return result;
        }

    }
}