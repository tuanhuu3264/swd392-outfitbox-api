using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.BusinessLayer.Services.PaymentService;

namespace SWD392.OutfitBox.API.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("online-payments/users/{userId}/money/{money}")]
        public async Task<IActionResult> PayOrderOnline([FromRoute] int userid, [FromRoute]double money)
        {
            var result = await _paymentService.CallAPIPayByUserId(userid, money);
            return Ok(result);
        }
        //[AllowAnonymous]
        //[HttpPost("online-payments/checked-payment")]
        //public async Task<IActionResult> ChangeStatusPayOrderOnline([FromBody] VNPayRequestDTO dto)
        //{
        //    var result = await _paymentService.GetInformationPayment(dto);
        //    return Ok(result);
        //}
    }
}
