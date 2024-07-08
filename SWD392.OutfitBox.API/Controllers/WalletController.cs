using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.DTOs.Wallet;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.Services.WalletService;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class WalletController : ControllerBase
    {
        public IWalletService _walletService;
        public IMapper _mapper;
        public WalletController(IMapper mapper, IWalletService walletService)
        {
            _walletService = walletService;
            _mapper = mapper;
        }
        [HttpGet("customers/{customerId}/wallets/")]
        public async Task<ActionResult<BaseResponse<List<WalletModel>>>> GetAllWalletsByUserId([FromRoute]int customerId)
        {
            BaseResponse<List<WalletModel>> response; 
            try
            {
                var data = await _walletService.GetAllWalletWithUserId(customerId);
                response = new BaseResponse<List<WalletModel>>("Get wallets by user successfully.", HttpStatusCode.OK, data);
            }catch(Exception ex)
            {
                response = new BaseResponse<List<WalletModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode,response);
        }
        [HttpGet("customers/{customerId}/wallets/actived-wallets")]
        public async Task<ActionResult<List<WalletModel>>> GetAllEnabledWalletsByUserId([FromRoute]int customerId)
        {
            BaseResponse<List<WalletModel>> response;
            try
            {
                var data = await _walletService.GetAllEnabledWalletWithUserId(customerId);
                response = new BaseResponse<List<WalletModel>>("Get wallets by user successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<WalletModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost("customers/{customerId}/wallets")]
        public async Task<ActionResult<BaseResponse<WalletModel>>> AddWalletByUserId([FromRoute] int id, [FromBody] CreateWalletRequestDTO createWalletRequestDTO)
        {
            BaseResponse<WalletModel> response;
            try
            {   
                var mapping = _mapper.Map<WalletModel>(createWalletRequestDTO);
                mapping.CustomerId = id;
                var data = await _walletService.AddWalletWithUserId(mapping);
                response = new BaseResponse<WalletModel>("Create wallet successfully.", HttpStatusCode.Created, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<WalletModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPatch("customers/{customerId}/wallets/{walletId}")]
        public async Task<ActionResult<BaseResponse<WalletModel>>> UpdateWalletByUserId([FromRoute] int walletId, [FromRoute] int id, [FromBody] UpdateWalletRequestDTO updateWalletRequestDTO)
        {
            BaseResponse<WalletModel> response;
            try
            {
                var mapping = _mapper.Map<WalletModel>(updateWalletRequestDTO);
                mapping.CustomerId= id;
                mapping.Id= id;

                var data = await _walletService.UpdateWalletWithUserId( mapping);
                response = new BaseResponse<WalletModel>("Update wallet successfully.", HttpStatusCode.Accepted, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<WalletModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPatch("wallets/{id}/status/{status}")]
        public async Task<ActionResult<BaseResponse<WalletModel>>> ActiveOrDeactiveWallet(int id)
        {
            BaseResponse<WalletModel> response;
            try
            {
                var data = await _walletService.ActiveOrDeactiveWalletById(id);
                response = new BaseResponse<WalletModel>("Update wallet successfully.", HttpStatusCode.Accepted, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<WalletModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
