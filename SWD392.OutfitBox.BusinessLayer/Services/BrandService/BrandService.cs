using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Firebase;
using SWD392.OutfitBox.DataLayer.Interfaces;
using SWD392.OutfitBox.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.BrandService
{
    public class BrandService : IBrandService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public IMapper _mapper { get; set; }
        public IConfiguration _configuration { get; set; }
        public BrandService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<List<BrandModel>> GetAllBrands()
        {
            var data = await _unitOfWork._brandRepository.GetAllBrands();
            return data.Select(x => _mapper.Map<BrandModel>(x)).ToList();
        }

        public async Task<BrandModel> CreateBrand(BrandModel brand)
        {
            var addedBrand = _mapper.Map<Brand>(brand);
            addedBrand.Status = 1;
            addedBrand.IsFeatured = true;
            var result = await _unitOfWork._brandRepository.CreateBrand(addedBrand);
            return _mapper.Map<BrandModel>(result);
        }

        public async Task<BrandModel> UpdateBrand(BrandModel brand)
        {
            if (brand.ID.HasValue == false) throw new Exception("There is no id in model.");
            var checking = await _unitOfWork._brandRepository.GetById(brand.ID.Value);
            if (checking == null) throw new ArgumentNullException("There is not found brand.");
   
            _mapper.Map(brand, checking, opt => opt.Items["PreserveExisting"] = true);

            var result = await _unitOfWork._brandRepository.UpdateBrand(checking);
            return _mapper.Map<BrandModel>(result);
        }

        public async Task<bool> DeleteBrand(int id)
        {

            var data = await _unitOfWork._brandRepository.GetById(id);
            if (data == null) throw new ArgumentNullException("There is not found brand.");
            if (data.Products?.Count > 0) throw new Exception("There are products in brand.");
            var result = await _unitOfWork._brandRepository.DeleteBrand(data);
            return result;
        }

        public async Task<BrandModel> UpdateStatus(int id, int status)
        {
            var data = await _unitOfWork._brandRepository.GetById(id);
            if (data == null) throw new ArgumentNullException("There is not found brand.");
            data.Status = status;
            if (status == 0) data.IsFeatured = false;
            var result = await _unitOfWork._brandRepository.UpdateBrand(data);
            return _mapper.Map<BrandModel>(result);
        }

        public async Task<BrandModel> GetBrandById(int id)
        {
            var result = await _unitOfWork._brandRepository.GetById(id);
            if (result == null) throw new ArgumentNullException("There is not found brand.");
            return _mapper.Map<BrandModel>(result);
        }

        public async Task<string> UploadBrandImage(IFormFile image)
        {
            var url = await FirebaseStorageHelper.UploadFileToFirebase(image, $"{nameof(Brand).ToLower()}", _configuration["Firebase:ApiKey"], _configuration["Firebase:DomainName"], _configuration["Firebase:Email"], _configuration["Firebase:Password"], _configuration["Firebase:StorageBucket"]);
            return url;
        }

        public async Task<List<BrandModel>> GetFeaturedBrands()
        {
            var data = (await _unitOfWork._brandRepository.GetAllBrands()).Where(x=>x.IsFeatured==true && x.Status==1);
            return data.Select(x => _mapper.Map<BrandModel>(x)).ToList();
        }
    }
}
