using Abp.Domain.Uow;
using Abp.Runtime.Caching;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Firebase;
using SWD392.OutfitBox.DataLayer.Interfaces;
using SWD392.OutfitBox.DataLayer.Streaming.ProducerMessage;
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
        private readonly StackExchange.Redis.IDatabase _cache;

        public PackageService( IPackageRepository packageRepository, IMapper mapper, IConfiguration configuration)
        {
            _packageRepository = packageRepository;
            _mapper = mapper;
            _configuration = configuration;
            ConnectionMultiplexer con = ConnectionMultiplexer.Connect("outfit4rent.online:6379");
            _cache = con.GetDatabase();
        }

        public async Task<PackageModel> ChangeStatus(int id, int status)
        {
            var package = await _packageRepository.GetPackageById(id);
            if (package == null) throw new Exception("Not found the package that has id: "+id);
            package.Status = status;
            if (status == 0) package.IsFeatured = false;
            var updatedPackage = await _packageRepository.UpdatePackage(package);
            var returnedPackage = _mapper.Map<PackageModel>(updatedPackage);
            if (updatedPackage != null)
            {
                Task.WhenAll(
                   ProducerMessage.ProductUpdateRedisMessage<Package>("update-all-packages", "delete", null, $"enabled-packages"),
                   ProducerMessage.ProductUpdateRedisMessage<Package>("update-all-packages", "delete", null, $"all-packages"),
                   ProducerMessage.ProductUpdateRedisMessage<Package>("update-all-packages", "delete", null, $"featured-packages")
               );
            }
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
            if (newPackage != null)
            {
                Task.WhenAll(
                   ProducerMessage.ProductUpdateRedisMessage<Package>("update-all-packages", "delete", null, $"enabled-packages"),
                   ProducerMessage.ProductUpdateRedisMessage<Package>("update-all-packages", "delete", null, $"all-packages"),
                   ProducerMessage.ProductUpdateRedisMessage<Package>("update-all-packages", "delete", null, $"featured-packages")
               );
            }
            return returnedPackage;

        }

        public async Task<List<PackageModel>> GetAllEnabledPackages()
        {
            try
            {
                var cachePackages = _cache.StringGet("enabled-packages").ToString();
                var result = JsonConvert.DeserializeObject<List<Package>>(cachePackages);
                if (cachePackages != null && cachePackages.Any())
                {
                    return cachePackages.Select(x => _mapper.Map<PackageModel>(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            var enabledPackages = (await _packageRepository.GetAllPackage()).Where(x => x.Status == 1).ToList();
            if(enabledPackages.Any())
            {
                Task.WhenAll(
                   ProducerMessage.ProductUpdateRedisMessage<List<Package>>("update-all-packages", "create", enabledPackages, "all-categories")
               );
            }
            var returnedPackages = enabledPackages.Select(x=>_mapper.Map<PackageModel>(x)).ToList();
            return returnedPackages;
        }

        public async Task<List<PackageModel>> GetAllPackages()
        {
            try
            {
                var cachePackages = _cache.StringGet("all-packages").ToString();
                var result = JsonConvert.DeserializeObject<List<Package>>(cachePackages);
                if (cachePackages != null && cachePackages.Any())
                {
                    return cachePackages.Select(x => _mapper.Map<PackageModel>(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            var packages = await _packageRepository.GetAllPackage();
            if (packages.Any())
            {
                Task.WhenAll(
                   ProducerMessage.ProductUpdateRedisMessage<List<Package>>("update-all-packages", "create", packages, "all-categories")
               );
            }
            var returnedPackages = packages.Select(x => _mapper.Map<PackageModel>(x)).ToList();
            return returnedPackages;
        }

        public async Task<List<PackageModel>> GetFeaturedPackages()
        {
            try
            {
                var cachePackages = _cache.StringGet("featured-packages").ToString();
                var result = JsonConvert.DeserializeObject<List<Package>>(cachePackages);
                if (cachePackages != null && cachePackages.Any())
                {
                    return cachePackages.Select(x => _mapper.Map<PackageModel>(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            var featuredPackages = (await _packageRepository.GetAllPackage()).Where(x => x.IsFeatured==true && x.Status==1).ToList();
            if (featuredPackages.Any())
            {
                Task.WhenAll(
                   ProducerMessage.ProductUpdateRedisMessage<List<Package>>("update-all-packages", "create", featuredPackages, "all-categories")
               );
            }
            var returnedPackages = featuredPackages.Select(x => _mapper.Map<PackageModel>(x)).ToList();
            return returnedPackages;
        }

        public async Task<PackageModel> GetPackageById(int v)
        {
            try
            {
                var cachePackages = _cache.StringGet($"packages-{v}").ToString();
                var data = JsonConvert.DeserializeObject<Package>(cachePackages);
                if (cachePackages != null && cachePackages.Any())
                {
                    return _mapper.Map<PackageModel>(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            var result = await _packageRepository.GetPackageById(v);
            if (result!=null)
            {
                Task.WhenAll(
                   ProducerMessage.ProductUpdateRedisMessage<Package>("update-all-packages", "create", result, $"packages-{result.Id}")
               );
            }
            return _mapper.Map<PackageModel>(result);
        }

        public async Task<PackageModel> GetPackageByIdV2(int v)
        {
            var result = await _packageRepository.GetPackageById(v);
            return _mapper.Map<PackageModel>(result);
        }

        public async Task<PackageModel> UpdatePackage(PackageModel packageDTO)
        {   
            var package = await _packageRepository.GetPackageById(packageDTO.Id.Value);
            package.Name = packageDTO.Name != null ? packageDTO.Name : package.Name;
            package.Status = packageDTO.Status.HasValue ? packageDTO.Status.Value :package.Status; 
            package.NumOfProduct = packageDTO.NumOfProduct.HasValue ? packageDTO.NumOfProduct.Value : package.NumOfProduct;
            package.Price = packageDTO.Price.HasValue ? packageDTO.Price.Value : package.Price;
            package.AvailableRentDays = packageDTO.AvailableRentDays.HasValue? packageDTO.AvailableRentDays.Value : package.AvailableRentDays;
            package.IsFeatured= packageDTO.IsFeatured.HasValue? packageDTO.IsFeatured.Value : package.IsFeatured;
            package.Description =packageDTO.Description!=null ? packageDTO.Description : package.Description;
            package.ImageUrl = packageDTO.ImageUrl!=null? packageDTO.ImageUrl :package.ImageUrl;
            var updatedPackage = await _packageRepository.UpdatePackage(package);
            if (updatedPackage != null)
            {
                Task.WhenAll(
                   ProducerMessage.ProductUpdateRedisMessage<Package>("update-all-packages", "delete", null, $"enabled-packages"),
                   ProducerMessage.ProductUpdateRedisMessage<Package>("update-all-packages", "delete", null, $"all-packages"),
                   ProducerMessage.ProductUpdateRedisMessage<Package>("update-all-packages", "delete", null, $"featured-packages")
               );
            }
            return _mapper.Map<PackageModel>(updatedPackage);
        }
        public async Task<string> UploadFile(IFormFile file)
        {
            var url = await FirebaseStorageHelper.UploadFileToFirebase(file, $"{nameof(Package).ToLower()}", _configuration["Firebase:ApiKey"], _configuration["Firebase:DomainName"], _configuration["Firebase:Email"], _configuration["Firebase:Password"], _configuration["Firebase:StorageBucket"]);
            return url;
        }
    }
}
