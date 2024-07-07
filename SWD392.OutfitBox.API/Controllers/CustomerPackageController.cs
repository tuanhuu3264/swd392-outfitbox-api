using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.DTOs.Customer;
using SWD392.OutfitBox.API.RequestModels.CustomerPackage;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.BusinessModels.PaymentModels;
using SWD392.OutfitBox.BusinessLayer.Services.UserPackageService;
using System.Net;

namespace SWD392.OutfitBox.API.Controllers
{
    public class CustomerPackageController : Controller
    {
        private readonly ICustomerPackageService _customerPackageService;
        private readonly IMapper _mapper;
        public CustomerPackageController(ICustomerPackageService customerPackageService, IMapper mapper)
        {
            _customerPackageService = customerPackageService;
            _mapper = mapper;
        }
        [HttpPatch("customers/packages/{id}/status/{status}")]
        public async Task<ActionResult<CustomerPackageModel>> UpdateCustomerPackage([FromRoute] int id, [FromRoute] int status)
        {
            BaseResponse<CustomerPackageModel> response;
            try
            {
                var result = await _customerPackageService.ChangeStatus(id, status);
                response = new BaseResponse<CustomerPackageModel>("Update customer successfully.", HttpStatusCode.OK, result);

            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<CustomerPackageModel>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CustomerPackageModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("customers/packages/{packageId}")]
        public async Task<ActionResult<CustomerPackageModel>> GetCustomerPackageById( [FromRoute] int packageId)
        {
            BaseResponse<CustomerPackageModel> response;
            try
            {
                var result = await _customerPackageService.GetPackagebyId(packageId);
                response = new BaseResponse<CustomerPackageModel>("Successfully", HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {
                response = new BaseResponse<CustomerPackageModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost("customers/packages")]
        public async Task<ActionResult<CustomerPackageModel>> CreateCustomerPackage([FromBody] CustomerPackageRequest request)
        {
            BaseResponse<CustomerPackageModel> response;
            try
            {
                var customerPackage = _mapper.Map<CustomerPackageModel>(request);
                var result = await _customerPackageService.CreateCustomerPackage(customerPackage);
                response = new BaseResponse<CustomerPackageModel>("Successfully", HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CustomerPackageModel>(ex.Message,HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }

    }
}
