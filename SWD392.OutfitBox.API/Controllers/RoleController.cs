using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Role;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Role;
using SWD392.OutfitBox.BusinessLayer.Services.RoleService;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class RoleController : ControllerBase
    {
        public IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet(RoleEndpoints.GetAllRoles)]
        public async Task<ActionResult<BaseResponse<List<RoleDTO>>>> GetAllRoles()
        {
            BaseResponse<List<RoleDTO>> response; 
            try 
            {
                var data = await _roleService.GetAllRoles();
                response = new BaseResponse<List<RoleDTO>>("Get all roles successfully.", HttpStatusCode.OK, data )
            } catch (Exception ex)
            {
                response = new BaseResponse<List<RoleDTO>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            
            return StatusCode((int)response.StatusCode,response); 
        }
        [HttpPost(RoleEndpoints.CreateRole)]
        public async Task<ActionResult<BaseResponse<CreateRoleResponseDTO>>> CreateRole([FromBody] CreateRoleRequestDTO createRoleRequestDTO)
        {
            BaseResponse<CreateRoleResponseDTO> response;
            try
            {
                var data = await _roleService.CreateRole(createRoleRequestDTO);
                response = new BaseResponse<CreateRoleResponseDTO>("Get all roles successfully.", HttpStatusCode.OK, data)
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CreateRoleResponseDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }

            return StatusCode((int)response.StatusCode, response);
        }
    }
}
