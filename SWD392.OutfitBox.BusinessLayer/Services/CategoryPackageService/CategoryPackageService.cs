using AutoMapper;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;

namespace SWD392.OutfitBox.BusinessLayer.Services.CategoryPackageService
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

        public async Task<CategoryPackageModel> CreatePackage(CategoryPackageModel request)
        {
            var mappingCategoryPackage = _mapper.Map<CategoryPackage>(request);
            mappingCategoryPackage.Status = 1;
            var createdCategoryPackage = await _categoryPackageRepository.CreateCategoryPackage(mappingCategoryPackage);
            return _mapper.Map<CategoryPackageModel>(createdCategoryPackage);
        }
        public async Task<bool> DeletePackageById(int id)
        {
            var result = await _categoryPackageRepository.DeleateCategoryPackageById(id);
            if (result == true) return true;
            return false;
        }

        public async Task<List<CategoryPackageModel>> GetAllCategoryPackagesByPackageId(int packageId)
        {   
            return (await _categoryPackageRepository.GetAllCategoryPackagesByPackageId(packageId)).Select(x => _mapper.Map<CategoryPackageModel>(x)).ToList();
        }

        public async Task<CategoryPackageModel> UpdatePackage(CategoryPackageModel request)
        {
            if (request.Id.HasValue == false) throw new Exception("There is no id in model.");
            var updatedCategoryPackage = await _categoryPackageRepository.GetCategoryPackageById(request.Id.Value);
            updatedCategoryPackage.Status = request.Status.HasValue ? request.Status.Value : updatedCategoryPackage.Status;
            updatedCategoryPackage.MaxAvailableQuantity = request.MaxAvailableQuantity.HasValue? request.MaxAvailableQuantity.Value : updatedCategoryPackage.MaxAvailableQuantity;
            // tu them di ku ??? giao cho lam keu tu them ??
            var returnedCategoryPackage = await _categoryPackageRepository.UpdateCategoryPackage(updatedCategoryPackage);
            
            return _mapper.Map<CategoryPackageModel>(returnedCategoryPackage);
            
        }
    }
}
