using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.Core.Models.Requests.Role;
using SWD392.OutfitBox.Core.Models.Responses.Role;
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
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(Context context) : base(context)
        {
        }

        public async Task<Role> CreateRole(Role createRoleRequestDTO)
        {
            await this.AddAsync(createRoleRequestDTO);
            await this.SaveChangesAsync();
            return await this.Get().OrderBy(x => x.Id).LastAsync();
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await this.Get().ToListAsync();
        }
    }
}
