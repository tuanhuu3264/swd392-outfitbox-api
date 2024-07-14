using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.Databases.Redis.Tasks;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.FirebaseCloudMessaging;
using SWD392.OutfitBox.DataLayer.Streaming.CosumerMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BackgroundWorker.ReturnMoneyTask
{
    public class NotificationUserBackgroundService : IHostedService
    {
        private readonly CancellationTokenSource _cts;
        private readonly ILogger<NotificationUserBackgroundService> _logger;
        private Task _executingTask;

        private readonly IDatabase _cache;
        private readonly ConnectionMultiplexer _redis;
        public NotificationUserBackgroundService(ILogger<NotificationUserBackgroundService> logger)
        {
            _redis = ConnectionMultiplexer.Connect("outfit4rent.online:6379");
            _cache = _redis.GetDatabase();
            _cts = new CancellationTokenSource();
            _logger = logger;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("NotificationUserBackgroundService is starting.");

            _executingTask = Task.Run(async () =>
            {
                while (!_cts.Token.IsCancellationRequested)
                {
                    try
                    {
                        (var message,var customerPackage) = await CosumerBrandMessage.ProcessMessageNotification(_cts.Token);
                        if (message != null)
                        {
                            var list = _cache.StringGet(customerPackage.CustomerId.ToString());
                            var model = JsonConvert.DeserializeObject<DeviceTokenModels>(list);
                            if (model.DeviceToken!=null && message.Notification!=null)
                            {
                                message.Token = model.DeviceToken;
                            }
                            await  FirebaseCloudMessagingHelper.SendNotificationByMessage(message);
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
