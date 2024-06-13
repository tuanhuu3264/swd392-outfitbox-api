using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Area;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Area;
using SWD392.OutfitBox.BusinessLayer.Services.AreaService;
using SWD392.OutfitBox.DataLayer.Entities;
using System.Runtime.InteropServices;
using System.Net;
using SWD392.OutfitBox.DataLayer.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Azure;
using static Google.Apis.Requests.BatchRequest;
using AutoMapper;
namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class AreaController : ControllerBase
    {
        public IAreaService _areaService { get; set; }
        public IMapper _mapper { get; set; }
        public AreaController(IAreaService areaService, IMapper mapper)
        {
            _areaService = areaService;
            _mapper = mapper;
        }

        [HttpGet("areas")]
        public async Task<ActionResult<BaseResponse<List<AreaDTO>>>> GetAllAreas()
        {
            var data = await _areaService.GetAllAreas();
            var response = new BaseResponse<List<AreaDTO>>("Get areas successfully.", HttpStatusCode.OK, data);
            return StatusCode((int)response.StatusCode, response);

        }
        [HttpPost("areas")]
        public async Task<ActionResult<BaseResponse<CreateAreaResponseDTO>>> CreateAreas([FromBody] CreateAreaRequestDTO createAreaRequestDTO)
        {   
            BaseResponse<CreateAreaResponseDTO> response;
            try
            {
                var data = await _areaService.CreateArea(createAreaRequestDTO);
                response = new BaseResponse<CreateAreaResponseDTO>("Create area successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CreateAreaResponseDTO>(ex.Message, HttpStatusCode.InternalServerError, null);

            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPatch("areas/{id}")]
        public async Task<ActionResult<BaseResponse<UpdateAreaResponseDTO>>> UpdateAreas([FromBody] UpdateAreaRequestDTO updateAreaRequestDTO, [FromRoute] int id)
        {
            BaseResponse<UpdateAreaResponseDTO> response;
            try
            {
                var mappingArea = _mapper.Map<Area>(updateAreaRequestDTO);
                mappingArea.Id = id;
                var data = await _areaService.UpdateArea(mappingArea);
                 response = new BaseResponse<UpdateAreaResponseDTO>("Update area successfully.", HttpStatusCode.OK, data);
            }
            catch(ArgumentNullException ex)
            {
                response = new BaseResponse<UpdateAreaResponseDTO>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                 response = new BaseResponse<UpdateAreaResponseDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
     
            }
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
