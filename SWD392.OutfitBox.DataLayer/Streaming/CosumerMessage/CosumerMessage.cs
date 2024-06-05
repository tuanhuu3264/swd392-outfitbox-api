using Confluent.Kafka;
using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Confluent.Kafka.ConfigPropertyNames;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace SWD392.OutfitBox.DataLayer.Streaming.CosumerMessage
{
    public class CosumerMessage
    {
        public CosumerMessage() { }
        public async Task ProccessProductMessage()
        {
            using (var c = new ConsumerBuilder<Ignore, string>(Config.GetConsumerConfig()).Build())
            {
                c.Subscribe("Products");

                CancellationTokenSource cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true; // Prevent the process from terminating.
                    cts.Cancel();
                };

                try
                {
                    // Seek to the end of the partition(s)
                    c.Assign(c.Assignment);
                    foreach (var partition in c.Assignment)
                    {
                        c.Seek(new TopicPartitionOffset(partition.Topic, partition.Partition, Offset.End));
                    }

                    // Consume the last message
                    try
                    {
                        var cr = c.Consume(cts.Token);
                        Console.WriteLine($"Consumed message '{cr.Value}' at: '{cr.TopicPartitionOffset}'.");
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Error occurred: {e.Error.Reason}");
                    }
                }
                catch (OperationCanceledException)
                {
                    // Ensure the c leaves the group cleanly and final offsets are committed.
                    c.Close();
                }
            }
        }
    }
}
