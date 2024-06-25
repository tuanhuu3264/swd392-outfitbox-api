

using Microsoft.AspNetCore.Http;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
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
        public Task<List<BrandModel>> GetAllBrands();
        public Task<List<BrandModel>> GetFeaturedBrands();
        public Task<BrandModel> CreateBrand(BrandModel brand);
        public Task<BrandModel> UpdateBrand(BrandModel brand);
        public Task<bool> DeleteBrand(int id);
        public Task<BrandModel> UpdateStatus(int id, int status);
        public Task<BrandModel> GetBrandById(int id);
        public Task<string> UploadBrandImage(IFormFile image);
    }
}
