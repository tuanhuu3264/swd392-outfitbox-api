using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<bool> CheckLogin(string username, string password);
        public Task<User> GetUserByEmail(string email);
    }
}
