using FAMS.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Domain.Entities;
using SWD392.OutfitBox.Infrastructure.Databases.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public async Task<User> ActiveOrDeActive(int id)
        {
            var user = await this.Get().FirstAsync(x=> x.Id == id);
            user.Status = Math.Abs(1 - user.Status); 
            return await this.Update(user);
        }

        public async Task<User> Create(User user)
        {
            return await this.AddAsync(user);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await this.Get().ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await this.Get().FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<User> GetUserByPhoneOrEmail(string phoneOrEmail)
        {
            var result = await this.Get().Include(x=>x.Role).FirstOrDefaultAsync(x=>x.Email.ToLower().Equals(phoneOrEmail.ToLower()) || x.Phone.Equals(phoneOrEmail));
            if (result == null) return new User();
            return result;
        }

        public async Task<List<User>> GetUsers()
        {
            return await this.Get().ToListAsync();
        }

        public async Task<User> Update(User user)
        {
            return await this.Update(user);    
        }

       
    }
}
