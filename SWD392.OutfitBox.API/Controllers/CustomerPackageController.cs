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
        [HttpPatch("orders/{id}/status/{status}")]
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
        [HttpGet("orders/{id}")]
        public async Task<ActionResult<CustomerPackageModel>> GetCustomerPackageById( [FromRoute] int id)
        {
            BaseResponse<CustomerPackageModel> response;
            try
            {
                var result = await _customerPackageService.GetPackagebyId(id);
                response = new BaseResponse<CustomerPackageModel>("Successfully", HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {
                response = new BaseResponse<CustomerPackageModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("orders/customers/{customerId}")]
        public async Task<ActionResult<List<CustomerPackageModel>>> GetCustomerPackageByCustomerId([FromRoute] int customerId)
        {
            BaseResponse<List<CustomerPackageModel>> response;
            try
            {
                var result = await _customerPackageService.GetAllCustomerPackageByCustomerId(customerId);
                response = new BaseResponse<List<CustomerPackageModel>>("Successfully", HttpStatusCode.OK, result.ToList());

            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<CustomerPackageModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("orders/status/{status}")]
        public async Task<ActionResult<List<CustomerPackageModel>>> GetCustomerPackageByStatus([FromRoute] int status)
        {
            BaseResponse<List<CustomerPackageModel>> response;
            try
            {
                var result = await _customerPackageService.GetCustomrPackagesByStatus(status);
                response = new BaseResponse<List<CustomerPackageModel>>("Successfully", HttpStatusCode.OK, result.ToList());

            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<CustomerPackageModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost("orders/customers/{customerId}/packages/{packageId}")]
        public async Task<ActionResult<CustomerPackageModel>> CreateCustomerPackage([FromBody] CustomerPackageRequest request, [FromRoute] int customerId, [FromRoute] int packageId)
        {
            BaseResponse<CustomerPackageModel> response;
            try
            {
                var customerPackage = _mapper.Map<CustomerPackageModel>(request);
                customerPackage.CustomerId = customerId;
                customerPackage.PackageId = packageId;
                var result = await _customerPackageService.CreateCustomerPackage(customerPackage,request.WalletId);
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
