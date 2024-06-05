using AutoMapper;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.CategoryPackage;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Package;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.CategoryPackage;
using SWD392.OutfitBox.Core.Models.Responses.Package;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.CategoryPackageService
{
    public class CategoryPackageService : ICategoryPackageService
    {
        public ICategoryPackageRepository _categoryPackageRepository;
        public IMapper _mapper;
        public CategoryPackageService(IMapper mapper, ICategoryPackageRepository categoryPackageRepository)
        {
            _categoryPackageRepository = categoryPackageRepository;
            _mapper = mapper;
        }

        public async Task<CreateCategoryPackageResponseDTO> CreatePackage(CreateCategoryPackageRequestDTO request)
        {
            var mappingCategoryPackage = _mapper.Map<CategoryPackage>(request);
            mappingCategoryPackage.Status = 1;
            var createdCategoryPackage = await _categoryPackageRepository.CreateCategoryPackage(mappingCategoryPackage);
            return _mapper.Map<CreateCategoryPackageResponseDTO>(createdCategoryPackage);
        }
        public async Task<DeleteCategoryPackageResponseDTO> DeletePackageById(int id)
        {
            var result = await _categoryPackageRepository.DeleateCategoryPackageById(id);
            if (result == true) return new DeleteCategoryPackageResponseDTO()
            {
                Message = "Delete CategoryPackage successfully."
            };
            return new DeleteCategoryPackageResponseDTO()
            {
                Message = "Delete CategoryPackage fail."
            };
        }

        public async Task<List<CategoryPackageDTO>> GetAllCategoryPackagesByPackageId(int packageId)
        {
            return (await _categoryPackageRepository.GetAllCategoryPackagesByPackageId(packageId)).Select(x => _mapper.Map<CategoryPackageDTO>(x)).ToList();
        }

        public async Task<UpdateCategoryPackageResponseDTO> UpdatePackage(UpdateCategoryPackageRequestDTO request)
        {
            var updatedCategoryPackage = await _categoryPackageRepository.GetCategoryPackageById(request.Id);
            updatedCategoryPackage.MaxAvailableQuantity = request.MaxAvailableQuantity;
            var returnedCategoryPackage = await _categoryPackageRepository.UpdateCategoryPackage(updatedCategoryPackage);
            return _mapper.Map<UpdateCategoryPackageResponseDTO>(returnedCategoryPackage);
            
        }
    }
}
