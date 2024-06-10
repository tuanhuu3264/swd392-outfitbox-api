using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Partner;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Partner;
using SWD392.OutfitBox.BusinessLayer.Services.PartnerService;
using System.Net;
namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class PartnerController : ControllerBase
    {
        public IPartnerService _partnerService {  get; set; }   
        public PartnerController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }
        [HttpGet(PartnerEndpoints.GetAllPartners)]
        public async Task<ActionResult<BaseResponse<List<PartnerDTO>>>> GetAllPartners()
        {
            BaseResponse<List<PartnerDTO>> response;
            try
            {
                var data = await _partnerService.GetAllPartners();
                response = new BaseResponse<List<PartnerDTO>>("Get partners successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<PartnerDTO>>(ex.Message, HttpStatusCode.InternalServerError, null); 
            }
            return StatusCode((int)response.StatusCode,response);
        }
        [HttpGet(PartnerEndpoints.GetPartnerById)]
        public async Task<ActionResult<BaseResponse<PartnerDTO>>> GetPartnerById([FromRoute] int id)
        {
            BaseResponse<PartnerDTO> response;
            try
            {
                var data = await _partnerService.GetPartnerById(id);
                response = new BaseResponse<PartnerDTO>("Get partner successfully.", HttpStatusCode.OK, data);
            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<PartnerDTO>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<PartnerDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost(PartnerEndpoints.CreatePartner)]
        public async Task<ActionResult<BaseResponse<CreatePartnerResponseDTO>>> CreatePartner([FromBody] CreatePartnerRequestDTO createPartnerRequestDTO)
        {
            BaseResponse<CreatePartnerResponseDTO> response;
            try
            {
                var data = await _partnerService.CreatePartner(createPartnerRequestDTO);
                response = new BaseResponse<CreatePartnerResponseDTO>("Create partner successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CreatePartnerResponseDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPut(PartnerEndpoints.UpdatePartner)]
        public async Task<ActionResult<UpdatePartnerResponseDTO>> UpdatePartner([FromBody] UpdatePartnerRequestDTO updatePartnerRequestDTO)
        {
            BaseResponse<UpdatePartnerResponseDTO> response;
            try
            {
                var data = await _partnerService.UpdatePartner(updatePartnerRequestDTO);
                response = new BaseResponse<UpdatePartnerResponseDTO>("Update partner successfully.", HttpStatusCode.OK, data);
            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<UpdatePartnerResponseDTO>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<UpdatePartnerResponseDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPut(PartnerEndpoints.ChangeStatus)]
        public async Task<ActionResult<BaseResponse<PartnerDTO>>> ChangeStatus([FromRoute] int id, [FromRoute] int status)
        {
            BaseResponse<PartnerDTO> response;
            try
            {
                var data = await _partnerService.ChangeStatus(id, status);
                response = new BaseResponse<PartnerDTO>("Update partner successfully.", HttpStatusCode.OK, data);
            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<PartnerDTO>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<PartnerDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
