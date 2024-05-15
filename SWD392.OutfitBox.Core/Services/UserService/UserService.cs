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
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> ActiveAndDeactiveUser(int id)
        {
            var condition = await _userRepository.GetUserById(id);
            if (condition == null) throw new Exception("Not found user has id: "+id);
            var result = await _userRepository.ActiveOrDeActive(id);
            return result;
        }

        public async Task<User> CreateUser(User user)
        {
            var result = await _userRepository.Create(user);
            return result;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var result = await _userRepository.GetAllUsers();
            return result;
        }

        public async Task<User> GetUserById(int id)
        {
            var result = await _userRepository.GetUserById(id);
            return result;
        }

        public async Task<User> UpdateUser(User user)
        {
            var result = await _userRepository.Update(user);
            return result;
        }
    }
}
