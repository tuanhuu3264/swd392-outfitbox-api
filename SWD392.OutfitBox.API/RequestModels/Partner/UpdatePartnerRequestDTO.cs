using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.Partner
{
    public class UpdatePartnerRequestDTO
    {
        public string? Name { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public int? AreaId { get; set; }
        public Coordinate? Coordinate { get; set; }
    }
}
