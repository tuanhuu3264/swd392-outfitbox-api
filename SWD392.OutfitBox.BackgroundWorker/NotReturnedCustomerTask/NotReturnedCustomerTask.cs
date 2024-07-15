using Abp.Extensions;
using FirebaseAdmin.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.FirebaseCloudMessaging;
using SWD392.OutfitBox.DataLayer.Streaming.ProducerMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BackgroundWorker.NotReturnedCustomerTask
{
    public class NotReturnedCustomerTask : IHostedService
    {
        public ILogger<NotReturnedCustomerTask> _logger;
        private readonly CancellationTokenSource _cts;
        private Task _executingTask;
        private Timer _timer;
        public NotReturnedCustomerTask(ILogger<NotReturnedCustomerTask> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("NotReturnedCustomer Background Service is starting.");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(12));
            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            try
            {
                var _context = new Context();
                _logger.LogInformation("Checking for customers with expired orders.");

                var customers = await _context.Set<ItemInUserPackage>()
                    .Include(x => x.UserPackage)
                    .Where(x => x.Quantity > x.ReturnedQuantity
                                && x.UserPackage.Status == 2
                                && !x.UserPackage.IsReturnedDeposit
                                && x.UserPackage.DateTo < DateTime.Now.AddDays(-4))
                    .Select(x => x.UserPackage.CustomerId)
                    .Distinct()
                    .ToListAsync();

                // Limit concurrency to 4 threads
                var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 4 };
                Parallel.ForEach(customers, parallelOptions, async (customerId) =>
                {
                    try
                    {
                        ConnectionMultiplexer _redis = ConnectionMultiplexer.Connect("outfit4rent.online:6379");
                        var stringData = await _redis.GetDatabase().StringGetAsync(customerId.ToString());

                        if (stringData.HasValue)
                        {
                            var data = JsonConvert.DeserializeObject<DeviceTokenModels>(stringData);
                            Message message = new Message()
                            {
                                Token = data.DeviceToken,
                                Notification = new Notification()
                                {
                                    Title = "Expired Products !!!!",
                                    Body = "Oops, you have expired products that have not been returned. Please check!",
                                }
                            };
                            await FirebaseCloudMessagingHelper.SendNotificationByMessage(message);
                        }
                        _logger.LogInformation($"Sending notification to customer {customerId} to return items.");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"Error processing customer {customerId}");
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in background task.");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
