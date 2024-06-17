using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.API.DTOs.Role;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;

using SWD392.OutfitBox.BusinessLayer.Services.RoleService;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class RoleController : ControllerBase
    {
        public IRoleService _roleService;
        public IMapper _mapper;
        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }
        [HttpGet(RoleEndpoints.GetAllRoles)]
        public async Task<ActionResult<BaseResponse<List<RoleModel>>>> GetAllRoles()
        {
            BaseResponse<List<RoleModel>> response; 
            try 
            {
                var data = await _roleService.GetAllRoles();
                response = new BaseResponse<List<RoleModel>>("Get all roles successfully.", HttpStatusCode.OK, data);
            } catch (Exception ex)
            {
                response = new BaseResponse<List<RoleModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            
            return StatusCode((int)response.StatusCode,response); 
        }
        [HttpPost(RoleEndpoints.CreateRole)]
        public async Task<ActionResult<BaseResponse<RoleModel>>> CreateRole([FromBody] CreateRoleRequestDTO createRoleRequestDTO)
        {
            BaseResponse<RoleModel> response;
            try
            {   
                var mapping = _mapper.Map<RoleModel>(createRoleRequestDTO);
                var data = await _roleService.CreateRole(mapping);
                response = new BaseResponse<RoleModel>("Get all roles successfully.", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<RoleModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }

            return StatusCode((int)response.StatusCode, response);
        }
    }
}
