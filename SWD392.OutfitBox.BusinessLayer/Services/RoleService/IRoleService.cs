
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.RoleService
{
    public interface IRoleService
    {
        public Task<List<RoleModel>> GetAllRoles();
        public Task<RoleModel> CreateRole(RoleModel createRoleRequestDTO);
    }
}
