using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Wallet;
using SWD392.OutfitBox.BusinessLayer.Services.WalletService;
using SWD392.OutfitBox.Core.Models.Responses.Wallet;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        [HttpGet("wallets/customers/{customerId}")]
        public async Task<ActionResult<BaseResponse<List<WalletDTO>>>> GetAllWalletsByUserId([FromRoute]int customerId)
        {
            BaseResponse<List<WalletDTO>> response; 
            try
            {
                var data = await _walletService.GetAllWalletWithUserId(customerId);
                response = new BaseResponse<List<WalletDTO>>("Get wallets by user successfully.", HttpStatusCode.OK, data);
            }catch(Exception ex)
            {
                response = new BaseResponse<List<WalletDTO>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode,response);
        }
        [HttpGet("wallets/actived-wallets/customers/{customerId}")]
        public async Task<ActionResult<List<WalletDTO>>> GetAllEnabledWalletsByUserId([FromRoute]int customerId)
        {
            BaseResponse<List<WalletDTO>> response;
            try
            {
                var data = await _walletService.GetAllEnabledWalletWithUserId(customerId);
                response = new BaseResponse<List<WalletDTO>>("Get wallets by user successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<WalletDTO>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost("wallets/customers/{customerId}")]
        public async Task<ActionResult<BaseResponse<CreateWalletResponseDTO>>> AddWalletByUserId([FromRoute] int id, [FromBody] CreateWalletRequestDTO createWalletRequestDTO)
        {
            BaseResponse<CreateWalletResponseDTO> response;
            try
            {
                var data = await _walletService.AddWalletWithUserId(id, createWalletRequestDTO);
                response = new BaseResponse<CreateWalletResponseDTO>("Create wallet successfully.", HttpStatusCode.Created, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CreateWalletResponseDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPut("wallets/customers/{customerId}")]
        public async Task<ActionResult<BaseResponse<UpdateWalletResponseDTO>>> UpdateWalletByUserId([FromRoute] int id, [FromBody] UpdateWalletRequestDTO updateWalletRequestDTO)
        {
            BaseResponse<UpdateWalletResponseDTO> response;
            try
            {
                var data = await _walletService.UpdateWalletWithUserId(id, updateWalletRequestDTO);
                response = new BaseResponse<UpdateWalletResponseDTO>("Update wallet successfully.", HttpStatusCode.Accepted, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<UpdateWalletResponseDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPut("wallets/{id}/status/{status}")]
        public async Task<ActionResult<BaseResponse<WalletDTO>>> ActiveOrDeactiveWallet(int id)
        {
            BaseResponse<WalletDTO> response;
            try
            {
                var data = await _walletService.ActiveOrDeactiveWalletById(id);
                response = new BaseResponse<WalletDTO>("Update wallet successfully.", HttpStatusCode.Accepted, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<WalletDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
