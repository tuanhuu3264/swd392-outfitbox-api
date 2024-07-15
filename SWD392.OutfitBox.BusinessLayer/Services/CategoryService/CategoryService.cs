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
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {   
        public ICategoryRepository _categoryRepository { get; set; }
        public IMapper _mapper;
        public IConfiguration _configuration;
        private readonly StackExchange.Redis.IDatabase _cache;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IConfiguration configuration)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _configuration = configuration;
            ConnectionMultiplexer con = ConnectionMultiplexer.Connect("outfit4rent.online:6379");
            _cache = con.GetDatabase();
        }
        public async Task<CategoryModel> ChangeStatus(int id, int status)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null) throw new Exception("Not found the category that has id: " + id);
            category.Status = status;
            if (status == 0) category.IsFeatured = false;
            var updatedCategory = await _categoryRepository.UpdateCategory(category);
            Task.WhenAll(
                    ProducerMessage.ProductUpdateRedisMessage<List<Category>>("update-all-categories", "delete", null, "all-categories"),
                    ProducerMessage.ProductUpdateRedisMessage<List<Category>>("update-all-categories", "delete", null, "featured-categories")
                );
            return _mapper.Map<CategoryModel>(updatedCategory);
        }

        public async Task<CategoryModel> CreateCategory(CategoryModel category)
        {
            category.Status = 1;
            var mappingCategory = _mapper.Map<Category>(category);
            var createdCategory = await _categoryRepository.CreateCategory(mappingCategory);
            Task.WhenAll(
                    ProducerMessage.ProductUpdateRedisMessage<List<Category>>("update-all-categories", "delete", null, "all-categories"),
                    ProducerMessage.ProductUpdateRedisMessage<List<Category>>("update-all-categories", "delete", null, "featured-categories")
                );
            return _mapper.Map<CategoryModel>(createdCategory);
        }

        public async Task<List<CategoryModel>> GetAllCategories()
        {
            try
            {
                var cacheCategories = _cache.StringGet("all-categories").ToString();
                var result = JsonConvert.DeserializeObject<List<Category>>(cacheCategories);
                if (cacheCategories != null && cacheCategories.Any())
                {
                    return cacheCategories.Select(x => _mapper.Map<CategoryModel>(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            var data = await _categoryRepository.GetAllCategories();
            if (data != null && data.Any())
            {
                Task.WhenAll(
                    ProducerMessage.ProductUpdateRedisMessage<List<Category>>("update-all-categories", "create", data, "all-categories")
                );
            }
            return _mapper.Map<List<CategoryModel>>(data);
        }

        public async Task<CategoryModel> GetCategoryById(int id)
        {
            try
            {
                var cacheCategories = _cache.StringGet($"categories-{id}").ToString();
                var result = JsonConvert.DeserializeObject<Category>(cacheCategories);
                if (cacheCategories != null && cacheCategories.Any())
                {
                    return _mapper.Map<CategoryModel>(result);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            var data= await _categoryRepository.GetById(id); 
            if(data!=null) Task.WhenAll(
                    ProducerMessage.ProductUpdateRedisMessage<Category>("update-all-categories", "create", data, $"Categories-{data.ID}")
                );
            return _mapper.Map<CategoryModel>(data);
        }

        public async Task<CategoryModel> UpdateCategory(CategoryModel category)
        {
            var checkingCategory = await _categoryRepository.GetById(category.ID.Value);

            if (checkingCategory == null) throw new Exception("Not found the category that has id: " + category.ID);
            
            checkingCategory.Name = category.Name!=null? category.Name: checkingCategory.Name;
            checkingCategory.Status = category.Status.HasValue? category.Status.Value: checkingCategory.Status;
            checkingCategory.ImageUrl = category.ImageUrl!=null? category.ImageUrl: checkingCategory.ImageUrl;
            checkingCategory.IsFeatured = category.IsFeatured.HasValue? category.IsFeatured.Value: checkingCategory.IsFeatured; 
            checkingCategory.Description = category.Description!=null? category.Description: checkingCategory.Description; 
            
            var updatedCategory = await _categoryRepository.UpdateCategory(checkingCategory);
            Task.WhenAll(
                    ProducerMessage.ProductUpdateRedisMessage<List<Category>>("update-all-categories", "delete", null, "all-categories"),
                    ProducerMessage.ProductUpdateRedisMessage<List<Category>>("update-all-categories", "delete", null, "featured-categories")
                );
            return _mapper.Map<CategoryModel>(updatedCategory);
        }
        public async Task<string> UploadCategoryImage(IFormFile image)
        {
            var url = await FirebaseStorageHelper.UploadFileToFirebase(image, $"{nameof(Category).ToLower()}", _configuration["Firebase:ApiKey"], _configuration["Firebase:DomainName"], _configuration["Firebase:Email"], _configuration["Firebase:Password"], _configuration["Firebase:StorageBucket"]);
            return url;
        }

        public async Task<List<CategoryModel>> GetFeaturedCategories()
        {
            try
            {
                var cacheCategories = _cache.StringGet("featured-categories").ToString();
                var result = JsonConvert.DeserializeObject<List<Category>>(cacheCategories);
                if (cacheCategories != null && cacheCategories.Any())
                {
                    return cacheCategories.Select(x => _mapper.Map<CategoryModel>(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            var data = (await _categoryRepository.GetAllCategories()).Where(x=>x.IsFeatured).ToList();
            if (data != null && data.Any())
            {
                Task.WhenAll(
                    ProducerMessage.ProductUpdateRedisMessage<List<Category>>("update-all-categories", "create", data, "featured-categories")
                );
            }
            return _mapper.Map<List<CategoryModel>>(data);
        }
    }
}
