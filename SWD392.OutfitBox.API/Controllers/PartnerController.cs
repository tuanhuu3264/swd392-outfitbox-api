using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.API.DTOs.Partner;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;

using SWD392.OutfitBox.BusinessLayer.Services.PartnerService;
using System.Net;
namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class PartnerController : ControllerBase
    {
        public IPartnerService _partnerService {  get; set; }
        public IMapper _mapper;
        public PartnerController(IMapper mapper, IPartnerService partnerService)
        {
            _partnerService = partnerService;
            _mapper = mapper;
        }
        [HttpGet(PartnerEndpoints.GetAllPartners)]
        public async Task<ActionResult<BaseResponse<List<PartnerModel>>>> GetAllPartners()
        {
            BaseResponse<List<PartnerModel>> response;
            try
            {
                var data = await _partnerService.GetAllPartners();
                response = new BaseResponse<List<PartnerModel>>("Get partners successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<PartnerModel>>(ex.Message, HttpStatusCode.InternalServerError, null); 
            }
            return StatusCode((int)response.StatusCode,response);
        }
        [HttpGet(PartnerEndpoints.GetPartnerById)]
        public async Task<ActionResult<BaseResponse<PartnerModel>>> GetPartnerById([FromRoute] int id)
        {
            BaseResponse<PartnerModel> response;
            try
            {
                var data = await _partnerService.GetPartnerById(id);
                response = new BaseResponse<PartnerModel>("Get partner successfully.", HttpStatusCode.OK, data);
            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<PartnerModel>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<PartnerModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost(PartnerEndpoints.CreatePartner)]
        public async Task<ActionResult<BaseResponse<PartnerModel>>> CreatePartner([FromBody] CreatePartnerRequestDTO createPartnerRequestDTO)
        {
            BaseResponse<PartnerModel> response;
            try
            {   
                var mapping = _mapper.Map<PartnerModel>(createPartnerRequestDTO);
                var data = await _partnerService.CreatePartner(mapping);
                response = new BaseResponse<PartnerModel>("Create partner successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<PartnerModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPatch("partners/{id}")]
        public async Task<ActionResult<PartnerModel>> UpdatePartner([FromRoute] int id, [FromBody] UpdatePartnerRequestDTO updatePartnerRequestDTO)
        {
            BaseResponse<PartnerModel> response;
            try
            {
                var mapping = _mapper.Map<PartnerModel>(updatePartnerRequestDTO);
                mapping.Id =id;
                var data = await _partnerService.UpdatePartner(mapping);
                response = new BaseResponse<PartnerModel>("Update partner successfully.", HttpStatusCode.OK, data);
            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<PartnerModel>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<PartnerModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPatch("partners/{id}/status/{status}")]
        public async Task<ActionResult<BaseResponse<PartnerModel>>> ChangeStatus([FromRoute] int id, [FromRoute] int status)
        {
            BaseResponse<PartnerModel> response;
            try
            {
                var data = await _partnerService.ChangeStatus(id, status);
                response = new BaseResponse<PartnerModel>("Update partner successfully.", HttpStatusCode.OK, data);
            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<PartnerModel>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<PartnerModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
