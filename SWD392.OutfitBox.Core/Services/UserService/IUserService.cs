using SWD392.OutfitBox.Core.Models.Requests.User;
using SWD392.OutfitBox.Core.Models.Responses.User;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.UserService
{
    public interface IUserService
    {
       public Task<List<UserDTO>> GetAllUsers();   
       
       public Task<UserDTO> GetUserById(int id);
       
       public Task<CreateUserResponseDTO> CreateUser(CreateUserRequestDTO user);

       public Task<UpdateUserResponseDTO> UpdateUser(UpdateUserRequestDTO user);
       
       public Task<UserDTO> ActiveAndDeactiveUser(int id);
    }
}
