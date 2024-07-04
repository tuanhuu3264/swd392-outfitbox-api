using Abp.Domain.Uow;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Firebase;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.PackageService
{
    public class PackageService : IPackageService
    {   
        public IPackageRepository _packageRepository;
        public IMapper _mapper;
        public IConfiguration _configuration;

        public PackageService( IPackageRepository packageRepository, IMapper mapper, IConfiguration configuration)
        {
            _packageRepository = packageRepository;
            _mapper = mapper;
            _configuration = configuration;
         
        }

        public async Task<PackageModel> ChangeStatus(int id, int status)
        {
            var package = await _packageRepository.GetPackageById(id);
            if (package == null) throw new Exception("Not found the package that has id: "+id);
            package.Status = status;
            if (status == 0) package.IsFeatured = false;
            var updatedPackage = await _packageRepository.UpdatePackage(package);
            var returnedPackage = _mapper.Map<PackageModel>(updatedPackage);
           
            return returnedPackage;
        }

        public async Task<PackageModel> CreatePackage(PackageModel package, List<CategoryPackageModel> categoryPackageModel)
        {   

            var mappingPackage = _mapper.Map<Package>(package);
            if (categoryPackageModel != null)
            {
                var categoryPackageLs = _mapper.Map<List<CategoryPackage>>(categoryPackageModel);
                categoryPackageLs.ForEach(x => x.Status = 1);
                mappingPackage.CategoryPackages = categoryPackageLs;
            }
            var createdPackage = await _packageRepository.CreatePackage(mappingPackage);
            var newPackage = (await _packageRepository.GetAllPackage()).OrderBy(x => x.Id).Last();
            var returnedPackage= _mapper.Map<PackageModel>(newPackage);
            return returnedPackage;
        }

        public async Task<List<PackageModel>> GetAllEnabledPackages()
        {
            var enabledPackages = (await _packageRepository.GetAllPackage()).Where(x => x.Status == 1).ToList();
            var returnedPackages = enabledPackages.Select(x=>_mapper.Map<PackageModel>(x)).ToList();
            return returnedPackages;
        }

        public async Task<List<PackageModel>> GetAllPackages()
        {
            var packages = await _packageRepository.GetAllPackage();
            var returnedPackages = packages.Select(x => _mapper.Map<PackageModel>(x)).ToList();
            return returnedPackages;
        }

        public async Task<List<PackageModel>> GetFeaturedPackages()
        {
            var featuredPackages = (await _packageRepository.GetAllPackage()).Where(x => x.IsFeatured==true && x.Status==1).ToList();
            var returnedPackages = featuredPackages.Select(x => _mapper.Map<PackageModel>(x)).ToList();
            return returnedPackages;
        }

        public async Task<PackageModel> GetPackageById(int id)
        {
            var package = await _packageRepository.GetPackageById(id);
            return _mapper.Map<PackageModel>(package);
        }

        public async Task<PackageModel> UpdatePackage(PackageModel packageDTO)
        {   
            var package = await _packageRepository.GetPackageById(packageDTO.Id.Value);
            _mapper.Map(packageDTO,package);
            var updatedPackage = await _packageRepository.UpdatePackage(package);
            return _mapper.Map<PackageModel>(updatedPackage);
        }
        public async Task<string> UploadFile(IFormFile file)
        {
            var url = await FirebaseStorageHelper.UploadFileToFirebase(file, $"{nameof(Package).ToLower()}", _configuration["Firebase:ApiKey"], _configuration["Firebase:DomainName"], _configuration["Firebase:Email"], _configuration["Firebase:Password"], _configuration["Firebase:StorageBucket"]);
            return url;
        }
    }
}
