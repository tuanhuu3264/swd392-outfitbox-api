using AutoMapper;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Brand;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Brand;
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
        public async Task<List<BrandDTO>> GetAllBrands()
        {
            var data = await _unitOfWork._brandRepository.GetAllBrands();
            return data.Select(x => _mapper.Map<BrandDTO>(x)).ToList();
        }

        public async Task<CreateBrandResponseDTO> CreateBrand(CreateBrandRequestDTO brand)
        {
            var addedBrand = _mapper.Map<Brand>(brand);
            addedBrand.Status = 1;
            addedBrand.IsFeatured = true;
            var result = await _unitOfWork._brandRepository.CreateBrand(addedBrand);
            return _mapper.Map<CreateBrandResponseDTO>(result);
        }

        public async Task<UpdateBrandResponseDTO> UpdateBrand(Brand brand)
        {
            var checking = await _unitOfWork._brandRepository.GetById(brand.ID);
            if (checking == null) throw new ArgumentNullException("There is not found brand.");

            if(brand.ImageUrl != null) checking.ImageUrl=brand.ImageUrl;
            if(brand.Name!=null) checking.Name=brand.Name;
            if(brand.Description!=null) checking.Description=brand.Description;

            var result = await _unitOfWork._brandRepository.UpdateBrand(checking);
            return _mapper.Map<UpdateBrandResponseDTO>(result);
        }

        public async Task<bool> DeleteBrand(int id)
        {

            var data = await _unitOfWork._brandRepository.GetById(id);
            if (data == null) throw new ArgumentNullException("There is not found brand.");
            if (data.Products?.Count > 0) throw new Exception("There are products in brand.");
            var result = await _unitOfWork._brandRepository.DeleteBrand(data);
            return result;
        }

        public async Task<BrandDTO> UpdateStatus(int id, int status)
        {
            var data = await _unitOfWork._brandRepository.GetById(id);
            if (data == null) throw new ArgumentNullException("There is not found brand.");
            data.Status = status;
            var result = await _unitOfWork._brandRepository.UpdateBrand(data);
            return _mapper.Map<BrandDTO>(result);
        }

        public async Task<BrandDTO> GetBrandById(int id)
        {
            var result = await _unitOfWork._brandRepository.GetById(id);
            if (result == null) throw new ArgumentNullException("There is not found brand.");
            return _mapper.Map<BrandDTO>(result);
        }
    }
}
