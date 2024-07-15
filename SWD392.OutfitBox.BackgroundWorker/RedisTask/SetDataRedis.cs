using Abp.Runtime.Caching;
using Castle.Core.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NRedisStack.RedisStackCommands;
using NReJSON;
using Org.BouncyCastle.Math.Field;
using StackExchange.Redis;
using SWD392.OutfitBox.DataLayer.Databases.Redis.Tasks;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Streaming.CosumerMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BackgroundWorker.RedisTask
{
    public class SetDataRedis : IHostedService
    {    
        ILogger<SetDataRedis> _logger;
        ConnectionMultiplexer _redis;
        IDatabase _cache;
        Task _executingTask;
        private readonly CancellationTokenSource _cts;
        public SetDataRedis(ILogger<SetDataRedis> logger)
        {
            _redis = ConnectionMultiplexer.Connect("outfit4rent.online:6379");
            _cache = _redis.GetDatabase();
            _logger = logger;
            _cts = new CancellationTokenSource();
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CosumerListen is starting.");

            _executingTask = Task.Run(async () =>
            {
                while (!_cts.Token.IsCancellationRequested)
                {
                    try
                    {
                        var message = await CosumerBrandMessage.ProcessMessageSetValueRedis<string>(_cts.Token);
                        if (message != null)
                        {
                            if(message.Command!="delete") _cache.StringSet(message.Key,message.Data);
                            else _cache.StringGetDelete(message.Key);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error processing Kafka message.");
                    }
                }
            }, cancellationToken);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CosumerListen is stopping.");

            _cts.Cancel();

            return Task.WhenAny(_executingTask, Task.Delay(Timeout.Infinite, cancellationToken));
        }
    }
}
