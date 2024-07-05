using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.DTOs.Customer;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.BusinessModels.PaymentModels;
using SWD392.OutfitBox.BusinessLayer.Services.UserPackageService;
using System.Net;

namespace SWD392.OutfitBox.API.Controllers
{
    public class CustomerPackageController : Controller
    {
        private readonly ICustomerPackageService _customerPackageService;
        public CustomerPackageController(ICustomerPackageService customerPackageService)
        {
            _customerPackageService = customerPackageService;
        }
        [HttpPatch("customers/package/{id},{status}")]
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
        [HttpGet("customers/{customerId}/package/{packageId}")]
        public async Task<ActionResult<CheckoutPackageModel>> GetCheckoutCustomerPackage([FromRoute] int customerId, [FromRoute] int packageId)
        {
            BaseResponse<CheckoutPackageModel> response;
            try
            {
                var result = await _customerPackageService.CheckoutPackage(customerId, packageId);
                response = new BaseResponse<CheckoutPackageModel>("Checkout", HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {
                response = new BaseResponse<CheckoutPackageModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }

            return StatusCode((int)response.StatusCode, response);
        }
        //[HttpPost("customers/{customerId/package}")]
        //public async Task<ActionResult<>>
    }
}
