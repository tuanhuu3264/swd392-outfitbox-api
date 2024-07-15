using Newtonsoft.Json;
using StackExchange.Redis;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BackgroundWorker.RedisTask
{
    public class DeviceTokenService
    {
        private readonly IDatabase _cache;
        private readonly ConnectionMultiplexer _redis;

        public DeviceTokenService()
        {
            _redis = ConnectionMultiplexer.Connect("outfit4rent.online:6379");
            _cache = _redis.GetDatabase();
        }

        public DeviceTokenModels AddDeviceToken(DeviceTokenModels deviceTokenModel)
        {
            var serializedModel = JsonConvert.SerializeObject(deviceTokenModel);
            _cache.StringSet(deviceTokenModel.Key.ToString(), serializedModel);
            return deviceTokenModel;
        }
        public DeviceTokenModels GetDeviceToken(int key)
        {
            var serializedModel = _cache.StringGet(key.ToString());
            if (serializedModel.IsNullOrEmpty)
            {
                throw new Exception("The Token is not exist");
            }
            return JsonConvert.DeserializeObject<DeviceTokenModels>(serializedModel);
        }
    }
}
