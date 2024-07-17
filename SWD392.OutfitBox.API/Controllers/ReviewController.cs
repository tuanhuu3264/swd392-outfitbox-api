using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Tnef;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.API.DTOs.Review;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.Services.ReviewService;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Repositories;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class ReviewController : ControllerBase
    {
        public IReviewService _reviewService;
        public IMapper _mapper;
        public ReviewController(IReviewService reviewService, IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }
        [HttpPut("reviews/actived-reviews")]
        public async Task<ActionResult<BaseResponse<List<ReviewModel>>>> GetAllEnabledReviews()
        {
            BaseResponse<List<ReviewModel>> response; 
            try 
            {
                var data = await _reviewService.GetAllEnabledReviews();
                response = new BaseResponse<List<ReviewModel>>("Get enable reviews successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<ReviewModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            
            return StatusCode((int)response.StatusCode,response);
        }
        [HttpGet("reviews/actived-reviews/customers/{customerId}")]
        public async Task<ActionResult<BaseResponse<List<ReviewModel>>>> GetAllEnabledReviewsByCustomerId([FromRoute]int customerId)
        {
            BaseResponse<List<ReviewModel>> response;
            try
            {
                var data = await _reviewService.GetAllEnabledReviewsByCustomerId(customerId);
                response = new BaseResponse<List<ReviewModel>>("Get reviews successfully by customer.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<ReviewModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet(ReviewEndpoints.GetReviewById)]
        public async Task<ActionResult<BaseResponse<ReviewModel>>> GetReviewById(int id)
        {
            BaseResponse<ReviewModel> response;
            try
            {
                var data = await _reviewService.GetReviewById(id);
                response = new BaseResponse<ReviewModel>("Get reviews successfully by customer.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<ReviewModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost(ReviewEndpoints.CreateReview)]
        public async Task<ActionResult<BaseResponse<ReviewModel>>> CreateReview([FromBody] CreateReviewRequestDTO request)
        {
            BaseResponse<ReviewModel> response;
            try
            {   
                var mapping = _mapper.Map<ReviewModel>(request);
                var data = await _reviewService.CreateReview(mapping);
                response = new BaseResponse<ReviewModel>("Create review successfully by customer.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<ReviewModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpDelete(ReviewEndpoints.DeleteReviewById)]
        public async Task<ActionResult<BaseResponse<string>>> DeleteReviewById([FromRoute] int id)
        {
            BaseResponse<string> response;
            try
            {
                var data = await _reviewService.DeleteReviewById(id);
                response = new BaseResponse<string>("Delete review successfully by customer.", HttpStatusCode.OK, "");
            }
            catch (Exception ex)
            {
                response = new BaseResponse<string>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("reviews/packages/{packageId}")]
        public async Task<ActionResult<BaseResponse<List<ReviewModel>>>> GetAllReviewsByPackageId([FromRoute] int packageId)
        {
            BaseResponse<List<ReviewModel>> response;
            try
            {
                var data = await _reviewService.GetAllReviewsByPackageId(packageId);
                response = new BaseResponse<List<ReviewModel>>("Get reviews successfully by package.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<ReviewModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("reviews/")]
        public async Task<ActionResult<BaseResponse<List<ReviewModel>>>> GetAllReviews()
        {
            BaseResponse<List<ReviewModel>> response;
            try
            {
                var data = await _reviewService.GetAllReviews();
                response = new BaseResponse<List<ReviewModel>>("Get reviews successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<ReviewModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }

            return StatusCode((int)response.StatusCode, response);
        }
    }
}
