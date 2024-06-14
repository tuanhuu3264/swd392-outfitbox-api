﻿using AutoMapper;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;

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
            var review = _mapper.Map<ReviewModel>(requestDTO);
            review.Date = DateTime.Now;
            review.Status = 0;
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

        public async Task<ReviewModel> GetReviewById(int id)
        {
            return _mapper.Map<ReviewModel>(await _reviewRepository.GetReviewById(id));
        }
    }
}