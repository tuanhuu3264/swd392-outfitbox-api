using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models.Responses.Area
{
    public class UpdateAreaResponseDTO
    {
        public int Id { get; set; }
        public string Ward = string.Empty;
        public string District { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}
