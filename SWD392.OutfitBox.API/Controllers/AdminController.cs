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
    }
}
