using SWD392.OutfitBox.BusinessLayer.Models.Responses.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.BrandRepository
{
    public interface IBrandService
    {
        public Task<List<BrandDTO>> GetAllBrands();
    }
}
