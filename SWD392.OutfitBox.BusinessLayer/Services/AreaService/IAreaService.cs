
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.AreaService
{
    public interface IAreaService
    {
        public Task<List<AreaModel>> GetAllAreas();
        public Task<AreaModel>CreateArea(AreaModel createAreaRequestDTO);
        public Task<AreaModel> UpdateArea(AreaModel updateAreaRequestDTO);
    }
}
