using AutoMapper;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Review;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Review;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<ReviewDTO> ActiveOrDeactiveReviewById(int id)
        {
            var result = await _reviewRepository.ActiveOrDeactiveReview(id);
            return _mapper.Map<ReviewDTO>(result);
        }

        public async Task<CreateReviewResponseDTO> CreateReview(CreateReviewRequestDTO requestDTO)
        {
            var review = _mapper.Map<ReviewModel>(requestDTO);
            review.Date = DateTime.Now;
            review.Status = 0;
            var result = await _reviewRepository.CreateReview(review);
            return _mapper.Map<CreateReviewResponseDTO>(result);
        }

        public async Task<DeleteReviewResponseDTO> DeleteReviewById(int id)
        {
            var result = await _reviewRepository.DeleteReviewById(id);
            if (result == true) return new DeleteReviewResponseDTO()
            {
                Message = "Delete Review Successfully."
            };
           return new DeleteReviewResponseDTO()
           {
               Message= "Delete Review Fail."
           };
        }

        public async Task<List<ReviewDTO>> GetAllEnabledReviews()
        {
            return (await _reviewRepository.GetAllEnabledReviews()).Select(x => _mapper.Map<ReviewDTO>(x)).ToList();
        }

        public async Task<List<ReviewDTO>> GetAllEnabledReviewsByCustomerId(int customerId)
        {
            return (await _reviewRepository.GetAllEnabledReviewsByCustomerId(customerId)).Select(x => _mapper.Map<ReviewDTO>(x)).ToList();
        }

        public async Task<ReviewDTO> GetReviewById(int id)
        {
            return _mapper.Map<ReviewDTO>(await _reviewRepository.GetReviewById(id));
        }
    }
}