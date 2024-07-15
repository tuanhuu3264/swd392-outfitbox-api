using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Streaming.ProducerMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BackgroundWorker.ReturnMoneyTask
{
    public class ReturnMoneyBackgroundService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly ILogger<ReturnMoneyBackgroundService> _logger;

        public ReturnMoneyBackgroundService(ILogger<ReturnMoneyBackgroundService> logger)
        {
            _logger = logger;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Return Money Background Service is starting.");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(24));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Return Money Background Service is stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            _logger.LogInformation("Return Money Background Service is working.");

            try
            {
                using var context = new Context();
                var customerPackages = await context.CustomerPackages
                    .Where(p => p.Status == 2 && !p.IsReturnedDeposit && p.DateTo.AddDays(4).Date == DateTime.Now.Date)
                    .Include(x => x.Items)
                    .ToListAsync();
                if (customerPackages.Any())
                {
                    var packageGroups = SplitList(customerPackages, 4);

                    var tasks = packageGroups.Select(group => Task.Run(async () => await ProcessPackages(group))).ToList();

                    await Task.WhenAll(tasks);
                }
                _logger.LogInformation("Return Money Background Service completed work successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
            }
        }

        private List<List<CustomerPackage>> SplitList(List<CustomerPackage> list, int n)
        {
            var listCount = list.Count;
            var groupSize = (listCount + n - 1) / n; // ceiling division
            return Enumerable.Range(0, n)
                .Select(i => list.Skip(i * groupSize).Take(groupSize).ToList())
                .ToList();
        }

        private async Task ProcessPackages(List<CustomerPackage> packages)
        {
            try
            {
                using var context = new Context();
                using var transaction = await context.Database.BeginTransactionAsync();

                foreach (var package in packages)
                {
                    var customer = await context.Set<Customer>().FirstOrDefaultAsync(x => x.Id == package.CustomerId);
                    if (customer == null) continue;

                    var returnOrders = await context.Set<ReturnOrder>()
                        .Where(x => x.CustomerPackageId == package.Id)
                        .ToListAsync();

                    var wallet = await context.Set<Wallet>()
                        .FirstOrDefaultAsync(x => x.CustomerId == customer.Id && x.WalletName == "Outfit4rent");

                    if (wallet == null) continue;

                    package.ReturnDeposit = (double)package.TotalDeposit;
                    package.ReturnDeposit -= returnOrders.Sum(x => x.TotalThornMoney);
                    package.IsReturnedDeposit = true;
                    context.Update(package);

                    customer.MoneyInWallet += (long)package.ReturnDeposit;
                    context.Update(customer);

                    var deposit = new Deposit()
                    {
                        CustomerId = customer.Id,
                        Type = "Return Money",
                        Date = DateTime.Now.Date,
                        AmountMoney = package.ReturnDeposit,
                        Transactions = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                DateTransaction = DateTime.Now,
                                Paymethod = "Online",
                                Status = 1,
                                Amount = package.ReturnDeposit,
                                WalletId = wallet.Id
                            }
                        }
                    };
                    context.Add(deposit);

                    await context.SaveChangesAsync();
                }

                await transaction.CommitAsync();

                foreach (var package in packages)
                {
                    await ProducerMessage.ProductProcessNotification("Return Money Is Successfully", "", package, "return-money-order-" + package.Id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while processing packages: {ex.Message}");
            }
        }
    }
}
