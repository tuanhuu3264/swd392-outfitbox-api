using AutoMapper;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Role;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Role;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.RoleService
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
        public async Task<CreateRoleResponseDTO> CreateRole(CreateRoleRequestDTO createRoleRequestDTO)
        {
            var addedRole= _mapper.Map<Role>(createRoleRequestDTO);
            var result =await _roleRepository.CreateRole(addedRole);
            var returnedRole = _mapper.Map<CreateRoleResponseDTO>(result);
            return returnedRole;
        }

        public async Task<List<RoleDTO>> GetAllRoles()
        {
            var roles = await _roleRepository.GetAllRoles();
            var returnedRoles = roles.Select(x=> _mapper.Map<RoleDTO>(x)).ToList();
            return returnedRoles;
        }
    }
}
