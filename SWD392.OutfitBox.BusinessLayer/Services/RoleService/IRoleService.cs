﻿
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Role;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.RoleService
{
    public interface IRoleService
    {
        public Task<List<RoleDTO>> GetAllRoles();
        public Task<CreateRoleResponseDTO> CreateRole(CreateRoleRequestDTO createRoleRequestDTO);
    }
}