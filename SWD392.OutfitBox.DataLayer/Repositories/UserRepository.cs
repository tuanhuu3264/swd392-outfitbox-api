using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public async Task<bool> CheckLogin(string username, string password)
        {
            var user = await this.Get().Where(x => x.Email.ToLower() == username && x.Password == password).FirstOrDefaultAsync(); 
            return user != null;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await this.Get().Include(x=>x.Role).Where(x => x.Email.ToLower() ==email).FirstOrDefaultAsync();
            return user;
        }
    }
}
