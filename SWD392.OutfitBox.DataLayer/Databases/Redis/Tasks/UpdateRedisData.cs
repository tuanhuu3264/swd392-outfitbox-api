using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Databases.Redis.Tasks
{
    public class UpdateRedisData
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<UpdateRedisData> _logger;

        public UpdateRedisData(IDistributedCache cache, ILogger<UpdateRedisData> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public async Task UpdateRedisAsync<Entity>(string key, Entity value, string command)
        {
            try
            {
                if (command != "delete")
                {
  
                   await _cache.SetRecordAsync<Entity>(key, value,TimeSpan.FromDays(1), TimeSpan.FromDays(1));
                    _logger.LogInformation($"Updated Redis key '{key}' with value '{value}'.");
                } 
                else
                {
                    await _cache.RemoveAsync(key);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating Redis key '{key}'.");
                throw;
            }
        }
    }
}
