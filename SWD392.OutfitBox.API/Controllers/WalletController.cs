using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.Core.Models.Requests.Wallet;
using SWD392.OutfitBox.Core.Models.Responses.Wallet;
using SWD392.OutfitBox.Core.Services.WalletService;

namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class WalletController : ControllerBase
    {
        public IWalletService _walletService; 
        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }
        [HttpGet(WalletEndpoints.GetAllWalletsByUserId)]
        public async Task<ActionResult<List<WalletDTO>>> GetAllWalletsByUserId([FromRoute]int userId)
        {
            return Ok(await _walletService.GetAllWalletWithUserId(userId));    
        }
        [HttpGet(WalletEndpoints.GetAllEnabledWalletsByUserId)]
        public async Task<ActionResult<List<WalletDTO>>> GetAllEnabledWalletsByUserId([FromRoute]int userId)
        {
            return Ok(await _walletService.GetAllEnabledWalletWithUserId(userId));
        }
        [HttpPost(WalletEndpoints.AddWalletsByUserId)]
        public async Task<ActionResult<CreateWalletResponseDTO>> AddWalletByUserId([FromRoute] int id, [FromBody] CreateWalletRequestDTO createWalletRequestDTO)
        {
            var result = await _walletService.AddWalletWithUserId(id, createWalletRequestDTO); 
            return Ok(result);
        }
        [HttpPut(WalletEndpoints.UpdateWalletByUserId)]
        public async Task<ActionResult<UpdateWalletResponseDTO>> UpdateWalletByUserId([FromRoute] int id, [FromBody] UpdateWalletRequestDTO updateWalletRequestDTO)
        {
            var result = await _walletService.UpdateWalletWithUserId(id, updateWalletRequestDTO);
            return Ok(result);
        }
        [HttpPut(WalletEndpoints.ActiveOrDeactiveWallet)]
        public async Task<ActionResult<WalletDTO>> ActiveOrDeactiveWallet(int id)
        {
            return Ok(await _walletService.ActiveOrDeactiveWalletById(id));
        }
    }
}
