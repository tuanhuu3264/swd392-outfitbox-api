using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Transaction;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Transaction;
using SWD392.OutfitBox.BusinessLayer.Services.TransactionService;
using SWD392.OutfitBox.DataLayer.Entities;
using System.Net;

namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class TransactionController : ControllerBase
    {
        public ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("transactions/customers/{customerId}")]
        public async Task<ActionResult<BaseResponse<List<TransactionDTO>>>> GetAllTransactionByUserId([FromRoute] int customerId)
        {
            BaseResponse<List<TransactionDTO>> response;
            try
            {
                var data = await _transactionService.GetAllTransactionsByUserId(customerId);
                response = new BaseResponse<List<TransactionDTO>>("Get transactions successfully.", HttpStatusCode.OK, data);
            }catch(Exception ex) 
            {
                response = new BaseResponse<List<TransactionDTO>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("transactions/customers/{customerId}/wallets/{walletId}")]
        public async Task<ActionResult<BaseResponse<List<TransactionDTO>>>> GetAllTransactionByWalletId([FromRoute] int walletId, [FromRoute] int userId)
        {
            BaseResponse<List<TransactionDTO>> response;
            try
            {
                var data = await _transactionService.GetAllTransactionsByWalletId(walletId,userId);
                response = new BaseResponse<List<TransactionDTO>>("Get transactions successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<TransactionDTO>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost("transactions/payments")]
        public async Task<ActionResult<string>> Checkout([FromBody] CheckoutTransactionRequestDTO checkoutTransactionRequestDTO)
        {
            BaseResponse<string> response;
            try
            {
                var data = await _transactionService.Checkout(checkoutTransactionRequestDTO);
                response = new BaseResponse<string>("Get transactions successfully.", HttpStatusCode.OK, "string");
            }
            catch (Exception ex)
            {
                response = new BaseResponse<string>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
