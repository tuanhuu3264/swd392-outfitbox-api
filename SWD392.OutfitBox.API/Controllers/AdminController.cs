﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.BusinessModels.AdminModel;
using SWD392.OutfitBox.BusinessLayer.Services.AdminService;
using SWD392.OutfitBox.DataLayer.Entities;
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
        [HttpGet("admin/number-transactions/")]
        public async Task<ActionResult<BaseResponse<AdminModel>>> GetNumberTransaction()
        {
            var data = await _adminService.GetNumberTransaction();
            var response = new BaseResponse<AdminModel>("daily-orders", HttpStatusCode.OK, data);
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("admin/trending-packages/")]
        public async Task<ActionResult<BaseResponse<List<AdminObjectData>>>> GetTrendingPackage()
        {
            var data = await _adminService.GetTrendingPackage();
            var response = new BaseResponse<List<AdminObjectData>>("daily-orders", HttpStatusCode.OK, data);
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("admin/quantity-renting/")]
        public async Task<ActionResult<BaseResponse<List<AdminObjectData>>>> GetQuantityRentingProduct()
        {
            var data = await _adminService.GetQuantityRentingProduct();
            var response = new BaseResponse<List<AdminObjectData>>("daily-orders", HttpStatusCode.OK, data);
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("admin/quantity-unreturned/")]
        public async Task<ActionResult<BaseResponse<List<AdminObjectData>>>> GetQuantityUnReturnedProduct()
        {
            var data = await _adminService.GetQuantityUnReturnedProduct();
            var response = new BaseResponse<List<AdminObjectData>>("daily-orders", HttpStatusCode.OK, data);
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("admin/number-completed-order/")]
        public async Task<ActionResult<BaseResponse<AdminModel>>> GetCompletedOrder()
        {
            var data = await _adminService.GetCompletedOrder();
            var response = new BaseResponse<AdminModel>("daily-orders", HttpStatusCode.OK, data);
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("admin/number-cancelled-order/")]
        public async Task<ActionResult<BaseResponse<AdminModel>>> GetCanceledOrder()
        {
            var data = await _adminService.GetCanceledOrder();
            var response = new BaseResponse<AdminModel>("daily-orders", HttpStatusCode.OK, data);
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("admin/number-lost-order/")]
        public async Task<ActionResult<BaseResponse<List<AdminObjectData>>>> GetLostProduct()
        {
            var data = await _adminService.GetLostProduct();
            var response = new BaseResponse<List<AdminObjectData>>("daily-orders", HttpStatusCode.OK, data);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
