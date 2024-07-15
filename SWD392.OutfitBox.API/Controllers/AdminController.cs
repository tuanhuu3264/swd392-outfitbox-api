using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.Services.AdminService;
using System.Net;

namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class AdminController : ControllerBase
    {
        public IAdminService _adminService { get; set; }
        public AdminController(IAdminService adminService) {
            _adminService = adminService;
        }
        [HttpGet("admin/new-customers")]
        public async Task<ActionResult<BaseResponse<AdminModel>>> GetAdminDailyRevenue()
        {
            var data = await _adminService.GetNewCustomers();
            var response = new BaseResponse<AdminModel>("new-customers", HttpStatusCode.OK, data);
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("admin/daily-revenue")]
        public async Task<ActionResult<BaseResponse<AdminModel>>> GetDailyOrdersRevenue()
        {
            var data = await _adminService.GetDailyRevenue();
            var response = new BaseResponse<AdminModel>("daily-revenue", HttpStatusCode.OK, data);
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("admin/daily-orders")]
        public async Task<ActionResult<BaseResponse<AdminModel>>> GetDailyOrders()
        {
            var data = await _adminService.GetDailyOrders();
            var response = new BaseResponse<AdminModel>("daily-orders", HttpStatusCode.OK, data);
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("admin/number-transactions/{kind}")]
        public async Task<ActionResult<BaseResponse<AdminModel>>> GetNumberTransaction([FromRoute]string kind)
        {
            var data = await _adminService.GetNumberTransaction(kind);
            var response = new BaseResponse<AdminModel>("daily-orders", HttpStatusCode.OK, data);
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("admin/trending-packages/{kind}")]
        public async Task<ActionResult<BaseResponse<List<AdminOjectModel>>>> GetTrendingPackage([FromRoute] string kind)
        {
            var data = await _adminService.GetTrendingPackage(kind);
            var response = new BaseResponse<List<AdminOjectModel>>("daily-orders", HttpStatusCode.OK, data);
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("admin/quantity-renting/{kind}")]
        public async Task<ActionResult<BaseResponse<List<AdminOjectModel>>>> GetQuantityRentigPoduct([FromRoute] string kind)
        {
            var data = await _adminService.GetQuantityRentigPoduct(kind);
            var response = new BaseResponse<List<AdminOjectModel>>("daily-orders", HttpStatusCode.OK, data);
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("admin/quantity-unt-returned/{kind}")]
        public async Task<ActionResult<BaseResponse<List<AdminOjectModel>>>> GetQuantityUnReturnedPoduct([FromRoute] string kind)
        {
            var data = await _adminService.GetQuantityUnReturnedPoduct(kind);
            var response = new BaseResponse<List<AdminOjectModel>>("daily-orders", HttpStatusCode.OK, data);
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("admin/number-completed-order/{kind}")]
        public async Task<ActionResult<BaseResponse<AdminModel>>> GetCompletedOrder([FromRoute] string kind)
        {
            var data = await _adminService.GetCompletedOrder(kind);
            var response = new BaseResponse<AdminModel>("daily-orders", HttpStatusCode.OK, data);
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("admin/number-cancelled-order/{kind}")]
        public async Task<ActionResult<BaseResponse<AdminModel>>> GetCanceledOrder([FromRoute] string kind)
        {
            var data = await _adminService.GetCanceledOrder(kind);
            var response = new BaseResponse<AdminModel>("daily-orders", HttpStatusCode.OK, data);
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("admin/number-lost-order/{kind}")]
        public async Task<ActionResult<BaseResponse<AdminModel>>> GetLostProduct([FromRoute] string kind)
        {
            var data = await _adminService.GetLostProduct(kind);
            var response = new BaseResponse<AdminModel>("daily-orders", HttpStatusCode.OK, data);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
