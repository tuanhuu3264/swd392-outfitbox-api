using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pipelines.Sockets.Unofficial;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.ReturnOrder;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.ReturnOrder;
using SWD392.OutfitBox.BusinessLayer.Services.ReturnOrderService;
using SWD392.OutfitBox.DataLayer.Entities;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SWD392.OutfitBox.API.Controllers
{

    [ApiController]
    public class ReturnOrderController : ControllerBase
    {
        public IReturnOrderService _returnOrderService;
        public ReturnOrderController(IReturnOrderService returnOrderService)
        {
            _returnOrderService = returnOrderService;
        }

        [HttpGet("return-orders")]
        public async Task<ActionResult<BaseResponse<List<ReturnOrderDTO>>>> GetReturnOrder(int? pageNumber = null, int? pageSize = null, int? partnerid = null, int? customerId = null)
        {
         

            var data = await _returnOrderService.GetReturnOrders(pageNumber, pageSize, partnerid, customerId);
            BaseResponse<List<ReturnOrderDTO>> response = new BaseResponse<List<ReturnOrderDTO>>("Get return orders successfully.",HttpStatusCode.OK,data);
            return StatusCode((int)response.StatusCode, response);

        }
        [HttpGet("return-orders/{id}")]
        public async Task<ActionResult<ReturnOrder>> GetById([FromRoute] int id)
        {
            BaseResponse<ReturnOrderDTO> response;
            try
            {
                var data = await _returnOrderService.GetReturnOrderById(id);
                response = new BaseResponse<ReturnOrderDTO>("Get return order successfully.", HttpStatusCode.OK, data);
            } 
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<ReturnOrderDTO>(ex.Message, HttpStatusCode.NotFound, null);
            } 
            catch (Exception ex)
            {
                response = new BaseResponse<ReturnOrderDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost("return-orders")]
        public async Task<ActionResult<BaseResponse<CreateReturnOrderResponseDTO>>> CreateReturnOrder([FromBody] CreateReturnOrderRequestDTO createReturnOrderRequestDTO)
        {
            BaseResponse<CreateReturnOrderResponseDTO> response;
            try
            {
                var data = await _returnOrderService.CreateReturnOrder(createReturnOrderRequestDTO);
                response = new BaseResponse<CreateReturnOrderResponseDTO>("Get return order successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CreateReturnOrderResponseDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpDelete("return-orders/{id}")]
        public async Task<ActionResult<BaseResponse<string>>> DeleteReturnOrder([FromRoute] int id)
        {
            BaseResponse<string> response;
            try
            {
                var data = await _returnOrderService.DeleteReturnOrder(id);
                response = new BaseResponse<string>("Delete return order successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<string>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPatch("return-orders/{id}/status/{status}")]
        public async Task<ActionResult<ReturnOrderDTO>> ChangeStatus([FromRoute] int id, [FromRoute] int status)
        {
            BaseResponse<ReturnOrderDTO> response;
            try
            {
                var data = await _returnOrderService.ChangeStatus(id,status);
                response = new BaseResponse<ReturnOrderDTO>("Change status return order successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<ReturnOrderDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }

    }
}
