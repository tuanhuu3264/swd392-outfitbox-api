using Abp.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Databases.Redis.Tasks;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Firebase;
using SWD392.OutfitBox.DataLayer.Interfaces;
using SWD392.OutfitBox.DataLayer.Streaming.CosumerMessage;
using SWD392.OutfitBox.DataLayer.Streaming.ProducerMessage;
using SWD392.OutfitBox.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace SWD392.OutfitBox.BusinessLayer.Services.BrandService
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IDistributedCache _distributedCache;
        private readonly UpdateRedisData _updateRedisData;
        public BrandService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, IDistributedCache distributedCache, UpdateRedisData updateRedisData)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
            _updateRedisData = updateRedisData;
        }

        public async Task<List<BrandModel>> GetAllBrands()
        {
            try
            {
                var cacheBrands = await _distributedCache.GetRecordAsync<List<Brand>>("all-brands");
                if (cacheBrands != null && cacheBrands.Any())
                {
                    return cacheBrands.Select(x => _mapper.Map<BrandModel>(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var data = await _unitOfWork._brandRepository.GetAllBrands();

            if (data != null && data.Any())
            {
                await Task.WhenAll(
                    ProducerMessage.ProductListBrandMessage("update-all-brands", "create", data, "all-brands")
                );
            }

            return data.Select(x => _mapper.Map<BrandModel>(x)).ToList();
        }

        public async Task<BrandModel> CreateBrand(BrandModel brand)
        {
            var addedBrand = _mapper.Map<Brand>(brand);
            addedBrand.Status = 1;
            addedBrand.IsFeatured = true;
            var result = await _unitOfWork._brandRepository.CreateBrand(addedBrand);

             await Task.WhenAll(
                ProducerMessage.ProductListBrandMessage("delete-all-brands", "delete", null, "all-brands"),
                ProducerMessage.ProductListBrandMessage("delete-featured-brands", "delete", null, "featured-brands")
            );

            return _mapper.Map<BrandModel>(result);
        }

        public async Task<BrandModel> UpdateBrand(BrandModel brand)
        {
            if (!brand.ID.HasValue)
            {
                throw new Exception("There is no id in model.");
            }

            var checking = await _unitOfWork._brandRepository.GetById(brand.ID.Value);
            if (checking == null)
            {
                throw new ArgumentNullException("There is not found brand.");
            }

            checking.Name = brand.Name ?? checking.Name;
            checking.ImageUrl = brand.ImageUrl ?? checking.ImageUrl;
            checking.Status = brand.Status ?? checking.Status;
            checking.Description = brand.Description ?? checking.Description;
            checking.IsFeatured = brand.IsFeatured ?? checking.IsFeatured;

            var result = await _unitOfWork._brandRepository.UpdateBrand(checking);

             Task.WhenAll(
                ProducerMessage.ProductBrandMessage("delete-brand", "delete", null, "Brands-"+brand.ID),
                ProducerMessage.ProductListBrandMessage("delete-all-brands", "delete", null, "all-brands"),
                ProducerMessage.ProductListBrandMessage("delete-featured-brands", "delete", null, "featured-brands")
            );

            return _mapper.Map<BrandModel>(result);
        }

        public async Task<bool> DeleteBrand(int id)
        {
            var data = await _unitOfWork._brandRepository.GetById(id);
            if (data == null)
            {
                throw new ArgumentNullException("There is not found brand.");
            }

            if (data.Products?.Count > 0)
            {
                throw new Exception("There are products in brand.");
            }

            var result = await _unitOfWork._brandRepository.DeleteBrand(data);
            Task.WhenAll(
                 ProducerMessage.ProductBrandMessage("delete-brand", "delete", null, "Brands-" + id),
                ProducerMessage.ProductListBrandMessage("delete-all-brands", "delete", null, "all-brands"),
                ProducerMessage.ProductListBrandMessage("delete-featured-brands", "delete", null, "featured-brands")
            );

            return result;
        }

        public async Task<BrandModel> UpdateStatus(int id, int status)
        {
            var data = await _unitOfWork._brandRepository.GetById(id);
            if (data == null)
            {
                throw new ArgumentNullException("There is not found brand.");
            }

            data.Status = status;
            if (status == 0)
            {
                data.IsFeatured = false;
            }

            var result = await _unitOfWork._brandRepository.UpdateBrand(data);

            Task.WhenAll(
                ProducerMessage.ProductBrandMessage("delete-brand", "delete", null, "Brands-" + id),
                ProducerMessage.ProductListBrandMessage("delete-all-brands", "delete", null, "all-brands"),
               ProducerMessage.ProductListBrandMessage("delete-featured-brands", "delete", null, "featured-brands"));

            return _mapper.Map<BrandModel>(result);
        }

        public async Task<BrandModel> GetBrandById(int id)
        {
            try
            {
                var cacheBrand = await _distributedCache.GetRecordAsync<Brand>($"{nameof(Brand)}s-{id}");
                if (cacheBrand != null)
                {
                    return _mapper.Map<BrandModel>(cacheBrand);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var result = await _unitOfWork._brandRepository.GetById(id);
            if (result == null)
            {
                throw new ArgumentNullException("There is not found brand.");
            }
            if(result.Products!=null)
            foreach(var item in result.Products)
            {
                item.Brand = null;
                item.Category = null;
            }
             await ProducerMessage.ProductBrandMessage("update-brand-" + id, "create", result, $"{nameof(Brand)}s-{id}");
            return _mapper.Map<BrandModel>(result);
        }

        public async Task<string> UploadBrandImage(IFormFile image)
        {
            var url = await FirebaseStorageHelper.UploadFileToFirebase(image, $"{nameof(Brand).ToLower()}", _configuration["Firebase:ApiKey"], _configuration["Firebase:DomainName"], _configuration["Firebase:Email"], _configuration["Firebase:Password"], _configuration["Firebase:StorageBucket"]);
            return url;
        }

        public async Task<List<BrandModel>> GetFeaturedBrands()
        {
            try
            {
                var cacheFeaturedBrands = await _distributedCache.GetRecordAsync<List<Brand>>("featured-brands");
                if (cacheFeaturedBrands != null && cacheFeaturedBrands.Any())
                {
                    return cacheFeaturedBrands.Select(x => _mapper.Map<BrandModel>(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var data = (await _unitOfWork._brandRepository.GetAllBrands()).Where(x => x.IsFeatured == true && x.Status == 1).ToList();

            if (data.Any())
            {
                 Task.WhenAll(
                    ProducerMessage.ProductListBrandMessage("update-all-brands", "create", data, "all-brands"),
                    ProducerMessage.ProductListBrandMessage("update-featured-brands", "update", data, "featured-brands")
                );

                await _distributedCache.SetRecordAsync("featured-brands", data);
            }

            return data.Select(x => _mapper.Map<BrandModel>(x)).ToList();
        }
    }
}
