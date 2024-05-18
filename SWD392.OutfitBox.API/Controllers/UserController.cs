using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.Core.Models.Requests.User;
using SWD392.OutfitBox.Core.Models.Responses.User;
using SWD392.OutfitBox.Core.Services.UserService;

namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet(UserEndpoints.GetAllUsers)]
        public async Task<ActionResult<List<UserDTO>>> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }
        [HttpGet(UserEndpoints.GetUserById)]
        public async Task<ActionResult<UserDTO>> GetUserById([FromRoute] int id)
        {
            return Ok(await _userService.GetUserById(id));
        }
        [HttpPost(UserEndpoints.CreateUser)]
        public async Task<ActionResult<CreateUserResponseDTO>> CreateUser([FromBody]CreateUserRequestDTO createUserRequestDTO)
        {
            var result = await _userService.CreateUser(createUserRequestDTO);
            return Ok(result);
        }
        [HttpPut(UserEndpoints.UpdateUser)]
        public async Task<ActionResult<UpdateUserResponseDTO>> UpdateUser([FromBody] UpdateUserRequestDTO updateUserRequestDTO)
        {
            var result = await _userService.UpdateUser(updateUserRequestDTO);
            return Ok(result);
        }
        [HttpPut(UserEndpoints.ActiveOrDeactiveUser)]
        public async Task<ActionResult<UserDTO>> ActiveOrDeactiveUser([FromRoute] int id)
        {
           return Ok(await _userService.ActiveAndDeactiveUser(id));
        }
    }
}
