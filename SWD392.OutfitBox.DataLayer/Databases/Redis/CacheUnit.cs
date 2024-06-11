using Microsoft.Identity.Client;
using NRedisStack;
using NRedisStack.RedisStackCommands;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NReJSON;
using System.Text.Json;
using System.Runtime.InteropServices;
using NRedisStack.Search.Literals.Enums;
using NRedisStack.Search;
namespace SWD392.OutfitBox.DataLayer.Databases.Redis
{
    public class CacheUnit<T> : ICacheUnit<T> where T : class
    {
        ConnectionMultiplexer redis { get; set; }
        IDatabase db { get; set; }
        IBloomCommands bf { get; set; }
        ICuckooCommands cf { get; set; }
        ICmsCommands cms { get; set; }
       
        ITopKCommands topk { get; set; }
        ITdigestCommands tdigest { get; set; }
        ISearchCommands ft { get; set; }
        IJsonCommands json { get; set; }
        ITimeSeriesCommands ts { get; set; }
        ConfigurationOptions options = new ConfigurationOptions
        {
            EndPoints = { { "outfit4rent.online", 6379 } }

        };
        public CacheUnit()
        {
            redis = ConnectionMultiplexer.Connect(options);
            db = redis.GetDatabase();
            bf = db.BF();
            cf = db.CF();
            cms = db.CMS();
    
            topk = db.TOPK();
            tdigest = db.TDIGEST();
            ft = db.FT();
            json = db.JSON();
            ts = db.TS();
        }
        public async Task<bool> Delete(string key)
        {
            return await db.KeyDeleteAsync(key);
        }

        public async Task<T> Get(Type type, object id)
        {
            var key = $"{type.Name}_{id.ToString()}";
            var result = await db.JSON().GetAsync(key);
            return result != null ? JsonSerializer.Deserialize<T>(result.ToString()) : default;
        }

        public async Task<List<T>> GetAll()
        {
            var server = redis.GetServer(redis.GetEndPoints().First());
            var keys = server.Keys(pattern: $"{typeof(T).Name}_*").ToArray();
            var results = new List<T>();

            foreach (var key in keys)
            {
                var result = await db.JSON().GetAsync(key);
                if (result != null)
                {
                    results.Add(JsonSerializer.Deserialize<T>(result.ToString()));
                }
            }

            return results;
        }

        public async Task<bool> SetObject(T obj, object id)
        {
            
            var jsonDb = db.JSON();
            if (jsonDb == null)
            {
                throw new NotImplementedException("OK");
            }

            // Ensure obj and id are not null
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            // Use typeof(T).Name instead of nameof(T) to get the type name
            string key = $"{typeof(T).Name}_{id.ToString()}";

            // Set the JSON object in the database
            await db.JSON().SetAsync(key, "$", obj);
            await db.KeyExpireAsync(key, TimeSpan.FromDays(1));
            return true;
        }
       /* public void Subscribe(Action<RedisChannel, RedisValue> handler)
        {
            sub.Subscribe(GetTopicName(), handler);
        }*/
    }
}
