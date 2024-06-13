using BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.VNPay;

namespace SWD392.OutfitBox.API.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("online-Payments/UserId={userid}/OrderId={orderid}")]
        public async Task<IActionResult> PayOrderOnline([FromRoute] int userid, [FromRoute] int orderid)
        {
            var result = await _paymentService.CallAPIPayByUserId(userid, orderid);
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpPost("0nline-Payments")]
        public async Task<IActionResult> ChangeStatusPayOrderOnline([FromBody] VNPayRequestDTO dto)
        {
            var result = await _paymentService.GetInformationPayment(dto);
            return Ok(result);
        }
    }
}
