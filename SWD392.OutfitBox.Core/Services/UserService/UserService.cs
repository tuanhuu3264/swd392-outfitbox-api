using AutoMapper;
using SWD392.OutfitBox.Core.Models.Requests.User;
using SWD392.OutfitBox.Core.Models.Responses.User;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        public IMapper _mapper;
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> ActiveAndDeactiveUser(int id)
        {
            var condition = await _userRepository.GetUserById(id);
            if (condition == null) throw new Exception("Not found user has id: "+id);
            var result = await _userRepository.ActiveOrDeActive(id);
            return _mapper.Map<UserDTO>(result);
        }

        public async Task<CreateUserResponseDTO> CreateUser(CreateUserRequestDTO user)
        {
            var mappingUser = _mapper.Map<User>(user);
            var result = await _userRepository.Create(mappingUser);
            return _mapper.Map<CreateUserResponseDTO>(result);
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var result = (await _userRepository.GetAllUsers()).Select(x=>_mapper.Map<UserDTO>(x)).ToList();
            return result;
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var result = _mapper.Map<UserDTO>(await _userRepository.GetUserById(id));
            return result;
        }

        public async Task<UpdateUserResponseDTO> UpdateUser(UpdateUserRequestDTO user)
        {
            var mappingUser = _mapper.Map<User>(user);
            var result = await _userRepository.UpdateUser(mappingUser);

            return _mapper.Map<UpdateUserResponseDTO>(result);
        }
    }
}
