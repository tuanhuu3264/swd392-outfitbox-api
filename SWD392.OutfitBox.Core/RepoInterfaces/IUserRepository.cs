using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.RepoInterfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllUsers(); 
        public Task<User> GetUserById(int id);
        public Task<User> Create(User user);
        public Task<User> Update(User user);
        public Task<User> ActiveOrDeActive(int id);

        public Task<User> GetUserByPhoneOrEmail(string phoneOrEmail);

    }
}
