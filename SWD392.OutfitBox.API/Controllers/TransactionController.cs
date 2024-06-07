using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Transaction;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Transaction;
using SWD392.OutfitBox.BusinessLayer.Services.TransactionService;

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

        [HttpGet(TransactionEndpoints.GetAllTransactionsByUserId)]
        public async Task<ActionResult<List<TransactionDTO>>> GetAllTransactionByUserId([FromRoute] int userId)
        {
            return Ok(await _transactionService.GetAllTransactionsByUserId(userId));
        }
        [HttpGet(TransactionEndpoints.GetAllTransactionsByWalletId)]
        public async Task<ActionResult<List<TransactionDTO>>> GetAllTransactionByWalletId([FromRoute] int walletId, [FromRoute] int userId)
        {
            return Ok(await _transactionService.GetAllTransactionsByWalletId(walletId,userId));
        }
        [HttpPost(TransactionEndpoints.Checkout)]
        public async Task<ActionResult<string>> Checkout([FromBody] CheckoutTransactionRequestDTO checkoutTransactionRequestDTO)
        {
            var result = await _transactionService.Checkout(checkoutTransactionRequestDTO);
            return Ok(result);
        }
    }
}
