using SWD392.OutfitBox.Core.Models.Requests.Role;
using SWD392.OutfitBox.Core.Models.Responses.Role;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.RepoInterfaces
{
    public interface IRoleRepository
    {
        public Task<Role> CreateRole(Role createRoleRequestDTO);
        public Task<List<Role>> GetAllRoles();
    }
}
