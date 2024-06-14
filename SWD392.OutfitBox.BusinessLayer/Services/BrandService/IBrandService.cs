using SWD392.OutfitBox.BusinessLayer.Models.Requests.Brand;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Brand;
using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.BrandService
{
    public interface IBrandService
    {
        public Task<List<BrandDTO>> GetAllBrands();
        public Task<CreateBrandResponseDTO> CreateBrand(CreateBrandRequestDTO brand);
        public Task<UpdateBrandResponseDTO> UpdateBrand(Brand brand);
        public Task<bool> DeleteBrand(int id);
        public Task<BrandDTO> UpdateStatus(int id, int status);
        public Task<BrandDTO> GetBrandById(int id);
    }
}
