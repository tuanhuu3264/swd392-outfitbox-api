using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.Role
{
    public class CreateRoleRequestDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;
    }
}
