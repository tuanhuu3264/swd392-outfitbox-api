using SWD392.OutfitBox.Core.Models.Requests.Area;
using SWD392.OutfitBox.Core.Models.Responses.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.AreaService
{
    public interface IAreaService
    {
        public Task<List<AreaDTO>> GetAllAreas();
        public Task<CreateAreaResponseDTO> CreateArea(CreateAreaRequestDTO createAreaRequestDTO);
        public Task<UpdateAreaResponseDTO> UpdateArea(UpdateAreaRequestDTO updateAreaRequestDTO);
    }
}
