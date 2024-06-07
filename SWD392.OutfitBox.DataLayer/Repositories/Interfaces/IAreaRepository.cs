using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Interfaces

{
    public interface IAreaRepository
    {
        public Task<List<Area>> GetAllArea();
        public Task<Area> CreateArea(Area addedArea);
        public Task<Area> UpdateArea(Area updatedArea);
        public Task<Area> GetById(int id);
    }
}
