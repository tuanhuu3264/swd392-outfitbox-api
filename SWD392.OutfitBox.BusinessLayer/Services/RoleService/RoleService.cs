using AutoMapper;

using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;

namespace SWD392.OutfitBox.BusinessLayer.Services.RoleService
{
    public class RoleService : IRoleService
    {   
        public IRoleRepository _roleRepository { get; set; }
        public IMapper _mapper;
        public RoleService(IRoleRepository roleRepository, IMapper mapper) 
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }    
        public async Task<RoleModel> CreateRole(RoleModel createRoleRequestDTO)
        {
            var addedRole= _mapper.Map<Role>(createRoleRequestDTO);
            var result =await _roleRepository.CreateRole(addedRole);
            var returnedRole = _mapper.Map<RoleModel>(result);
            return returnedRole;
        }

        public async Task<List<RoleModel>> GetAllRoles()
        {
            var roles = await _roleRepository.GetAllRoles();
            var returnedRoles = roles.Select(x=> _mapper.Map<RoleModel>(x)).ToList();
            return returnedRoles;
        }
    }
}
