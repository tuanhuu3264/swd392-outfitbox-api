using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SWD392.OutfitBox.DataLayer.Databases.Redis.Tasks;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Streaming.CosumerMessage;

public class CosumerBrandListen : IHostedService
{
    private readonly CancellationTokenSource _cts;
    private readonly UpdateRedisData _updateRedisData;
    private readonly ILogger<CosumerBrandListen> _logger;
    private Task _executingTask;

    public CosumerBrandListen(UpdateRedisData updateRedisData, ILogger<CosumerBrandListen> logger)
    {
        _cts = new CancellationTokenSource();
        _updateRedisData = updateRedisData;
        _logger = logger;
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
                    var message = await CosumerBrandMessage.ProcessMessageSetValueRedis(_cts.Token);
                    if (message != null)
                    {
                        await _updateRedisData.UpdateRedisAsync<Brand>($"{message.Key}", message.Data, message.Command);
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

public class CosumerListBrandListen : IHostedService
{
    private readonly CancellationTokenSource _cts;
    private readonly UpdateRedisData _updateRedisData;
    private readonly ILogger<CosumerBrandListen> _logger;
    private Task _executingTask;

    public CosumerListBrandListen(UpdateRedisData updateRedisData, ILogger<CosumerBrandListen> logger)
    {
        _cts = new CancellationTokenSource();
        _updateRedisData = updateRedisData;
        _logger = logger;
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
                    var message = await CosumerBrandMessage.ProcessMessageSetListValueRedis(_cts.Token);
                    if (message != null)
                    {
                        await _updateRedisData.UpdateRedisAsync<List<Brand>>($"{message.Key}", message.Data, message.Command);
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