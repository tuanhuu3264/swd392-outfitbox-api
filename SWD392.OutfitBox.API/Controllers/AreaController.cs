using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Services.AreaService;
using SWD392.OutfitBox.DataLayer.Entities;
using System.Runtime.InteropServices;
using System.Net;
using SWD392.OutfitBox.DataLayer.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Azure;
using AutoMapper;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.API.DTOs.Area;
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
        public async Task<ActionResult<BaseResponse<List<AreaModel>>>> GetAllAreas()
        {
            var data = await _areaService.GetAllAreas();
            var response = new BaseResponse<List<AreaModel>>("Get areas successfully.", HttpStatusCode.OK, data);
            return StatusCode((int)response.StatusCode, response);

        }
        [HttpPost("areas")]
        public async Task<ActionResult<BaseResponse<AreaModel>>> CreateAreas([FromBody] CreateAreaRequestDTO createAreaRequestDTO)
        {   
            BaseResponse<AreaModel> response;
            try
            {   var mapping = _mapper.Map<AreaModel>(createAreaRequestDTO);
                var data = await _areaService.CreateArea(mapping);
                response = new BaseResponse<AreaModel>("Create area successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<AreaModel>(ex.Message, HttpStatusCode.InternalServerError, null);

            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPatch("areas/{id}")]
        public async Task<ActionResult<BaseResponse<AreaModel>>> UpdateAreas([FromBody] UpdateAreaRequestDTO updateAreaRequestDTO, [FromRoute] int id)
        {
            BaseResponse<AreaModel> response;
            try
            {
                var mappingArea = _mapper.Map<AreaModel>(updateAreaRequestDTO);
                mappingArea.Id = id;
                var data = await _areaService.UpdateArea(mappingArea);
                 response = new BaseResponse<AreaModel>("Update area successfully.", HttpStatusCode.OK, data);
            }
            catch(ArgumentNullException ex)
            {
                response = new BaseResponse<AreaModel>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                 response = new BaseResponse<AreaModel>(ex.Message, HttpStatusCode.InternalServerError, null);
     
            }
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
