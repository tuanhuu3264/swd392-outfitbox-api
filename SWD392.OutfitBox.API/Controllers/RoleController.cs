using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.Core.Models.Requests.Role;
using SWD392.OutfitBox.Core.Models.Responses.Role;
using SWD392.OutfitBox.Core.Services.RoleService;

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
        public async Task<ActionResult<List<RoleDTO>>> GetAllRoles()
        {
            var result = await _roleService.GetAllRoles();
            return Ok(result); 
        }
        [HttpPost(RoleEndpoints.CreateRole)]
        public async Task<ActionResult<CreateRoleResponseDTO>> CreateRole([FromBody] CreateRoleRequestDTO createRoleRequestDTO)
        {
            var result = await _roleService.CreateRole(createRoleRequestDTO);
            return Ok(result);
        }
    }
}
