using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Tnef;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Review;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Review;
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
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpPut(ReviewEndpoints.GetAllEnabledReviews)]
        public async Task<ActionResult<BaseResponse<List<ReviewDTO>>>> GetAllEnabledReviews()
        {
            BaseResponse<List<ReviewDTO>> response; 
            try 
            {
                var data = await _reviewService.GetAllEnabledReviews();
                response = new BaseResponse<List<ReviewDTO>>("Get enable reviews successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<ReviewDTO>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            
            return StatusCode((int)response.StatusCode,response);
        }
        [HttpGet(ReviewEndpoints.GetAllEnabledReviewsByCustomerId)]
        public async Task<ActionResult<BaseResponse<List<ReviewDTO>>>> GetAllEnabledReviewsByCustomerId([FromRoute]int customerId)
        {
            BaseResponse<List<ReviewDTO>> response;
            try
            {
                var data = await _reviewService.GetAllEnabledReviewsByCustomerId(customerId);
                response = new BaseResponse<List<ReviewDTO>>("Get reviews successfully by customer.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<ReviewDTO>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet(ReviewEndpoints.GetReviewById)]
        public async Task<ActionResult<BaseResponse<ReviewDTO>>> GetReviewById(int id)
        {
            BaseResponse<ReviewDTO> response;
            try
            {
                var data = await _reviewService.GetReviewById(id);
                response = new BaseResponse<ReviewDTO>("Get reviews successfully by customer.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<ReviewDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost(ReviewEndpoints.CreateReview)]
        public async Task<ActionResult<BaseResponse<CreateReviewResponseDTO>>> CreateReview([FromBody] CreateReviewRequestDTO request)
        {
            BaseResponse<CreateReviewResponseDTO> response;
            try
            {
                var data = await _reviewService.CreateReview(request);
                response = new BaseResponse<CreateReviewResponseDTO>("Create review successfully by customer.", HttpStatusCode.Created, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CreateReviewResponseDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
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
    }
}
