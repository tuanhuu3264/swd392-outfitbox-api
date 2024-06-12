using AutoMapper;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Brand;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Brand;
using SWD392.OutfitBox.DataLayer.Interfaces;
using SWD392.OutfitBox.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.BrandRepository
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
            try
            {
                var data = await _unitOfWork._brandRepository.GetAllBrands();
                return data.Select(x=>_mapper.Map<BrandDTO>(x)).ToList();
            } catch(Exception ex) 
            { 
             throw new Exception(ex.Message);
            }

        }

        public Task<CreateBrandResponseDTO> CreateBrand(CreateBrandRequestDTO brand)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateBrandResponseDTO> UpdateBrand(UpdateBrandRequestDTO brand)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteBrand(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BrandDTO> UpdateStatus(int id)
        {
            throw new NotImplementedException();
        }
    }
}
