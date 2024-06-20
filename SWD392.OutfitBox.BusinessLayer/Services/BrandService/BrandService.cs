﻿using AutoMapper;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.Entities;
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
        public BrandService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

            if(brand.ImageUrl != null) checking.ImageUrl=brand.ImageUrl;
            if(brand.Name!=null) checking.Name=brand.Name;
            if(brand.Description!=null) checking.Description=brand.Description;

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
            var result = await _unitOfWork._brandRepository.UpdateBrand(data);
            return _mapper.Map<BrandModel>(result);
        }

        public async Task<BrandModel> GetBrandById(int id)
        {
            var result = await _unitOfWork._brandRepository.GetById(id);
            if (result == null) throw new ArgumentNullException("There is not found brand.");
            return _mapper.Map<BrandModel>(result);
        }
    }
}