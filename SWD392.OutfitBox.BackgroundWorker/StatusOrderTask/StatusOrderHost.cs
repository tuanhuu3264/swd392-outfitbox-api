using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NetTopologySuite.Index.HPRtree;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Streaming.ProducerMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BackgroundWorker.StatusOrderTask
{
    public class StatusOrderHost : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly Context _context;
        public StatusOrderHost()
        {
            _context ??= new Context();
        }
        public void Dispose()
        {
            _timer?.Dispose();
            _context.Dispose();
        }

        Task IHostedService.StartAsync(CancellationToken cancellationToken)
        {
                    _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(12));
                    return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            Dispose();
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            try
            {
                var customerPackages = _context.CustomerPackages
                    .Where(p => p.DateTo <= DateTime.Today && p.Status !=2 && p.Status !=-1)
                    .Include(x=>x.Items)
                    .ToList();              
                foreach (var customerPackage in customerPackages)
                {
                    customerPackage.Status = 2;
                    foreach(var item in customerPackage.Items)
                    {
                        item.Status = 2;
                    }
                    ProducerMessage.ProductUpdateRedisMessage<CustomerPackage>("delete-customer-packages-byId" + customerPackage.Id, "delete", null, $"customer-packages-id:{customerPackage.Id}");
                }
                _context.SaveChanges();
                Task.WhenAll(
                         ProducerMessage.ProductUpdateRedisMessage<List<CustomerPackage>>("delete-customer-packages-by-customerId", "delete", null, $"customer-packages-status:{1}"),
                         ProducerMessage.ProductUpdateRedisMessage<List<CustomerPackage>>("delete-customer-packages-by-customerId", "delete", null, $"customer-packages-status:{2}")
                 );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
