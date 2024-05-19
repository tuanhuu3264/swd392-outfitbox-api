using AutoMapper;
using SWD392.OutfitBox.Core.Models.Requests.Package;
using SWD392.OutfitBox.Core.Models.Responses.Package;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.PackageService
{
    public class PackageService : IPackageService
    {   
        public IPackageRepository _packageRepository;
        public IMapper _mapper;
        public PackageService(IPackageRepository packageRepository, IMapper mapper)
        {
            _packageRepository = packageRepository;
            _mapper = mapper;
        }

        public async Task<PackageDTO> ActiveOrDeactivePackageById(int id)
        {
            var package = await _packageRepository.GetPackageById(id);
            if (package == null) throw new Exception("Not found the package that has id: "+id);
            package.Status = Math.Abs(1-package.Status);
            var updatedPackage = await _packageRepository.UpdatePackage(package);
            var returnedPackage= _mapper.Map<PackageDTO>(updatedPackage);
            returnedPackage.CategoryPackages = updatedPackage.CategoryPackages?.Select(x=> new CategoryPackageDTO() {
              CategoryId = x.Id,
              CategoryName=x.Category!= null ? x.Category.Name:"",
              MaxAvailableQuantity=x.MaxAvailableQuantity
            }).ToArray();
            return returnedPackage;
        }

        public async Task<CreatePackageResponseDTO> CreatePackage(CreatePackageRequestDTO package)
        {
            var mappingPackage = _mapper.Map<Package>(package);

            var createdCategoriesInPackage = package.CategoryPackages?.Select(x => new CategoryPackage()
            {
                CategoryId=x.CategoryId,
                MaxAvailableQuantity=x.MaxAvailableQuantity,
            });

            mappingPackage.CategoryPackages = createdCategoriesInPackage?.ToList();

            var createdPackage = await _packageRepository.CreatePackage(mappingPackage);

            var newPackage = (await _packageRepository.GetAllPackage()).OrderBy(x => x.Id).Last();

            var returnedPackage= _mapper.Map<CreatePackageResponseDTO>(newPackage);
            return returnedPackage;
        }

        public async Task<List<PackageDTO>> GetAllEnabledPackages()
        {
            var enabledPackages = (await _packageRepository.GetAllPackage()).Where(x => x.Status == 1).ToList();
            var returnedPackages = enabledPackages.Select(x=>_mapper.Map<PackageDTO>(x)).ToList();
            return returnedPackages;
        }

        public async Task<List<PackageDTO>> GetAllPackages()
        {
            var packages = await _packageRepository.GetAllPackage();
            var returnedPackages = packages.Select(x => _mapper.Map<PackageDTO>(x)).ToList();
            return returnedPackages;
        }

        public async Task<UpdatePackageResponseDTO> UpdatePackage(UpdatePackageRequestDTO packageDTO)
        {   
            var mappingPackage = _mapper.Map<Package>(packageDTO);
            var package = await _packageRepository.GetPackageById(mappingPackage.Id);
            package.Status = packageDTO.Status;
            package.Price= packageDTO.Price;
            package.Description= packageDTO.Description;
            package.AvailableRentDays = packageDTO.AvailableRentDays;
            package.Name = packageDTO.Name;
            if (package.CategoryPackages != null)
                foreach(CategoryPackage categoryPackage in package.CategoryPackages)
                {
                    if(packageDTO.CategoryPackages!=null && packageDTO.CategoryPackages.Select(x=>x.CategoryId).Contains(categoryPackage.CategoryId)) 
                    { 
                        var updatedCategoryPackage = packageDTO.CategoryPackages.First(x=>x.CategoryId == categoryPackage.CategoryId);
                        categoryPackage.MaxAvailableQuantity = updatedCategoryPackage.MaxAvailableQuantity;
                    }
                }
            var updatedPackage = await _packageRepository.UpdatePackage(package);
            return _mapper.Map<UpdatePackageResponseDTO>(updatedPackage);
        }
    }
}
