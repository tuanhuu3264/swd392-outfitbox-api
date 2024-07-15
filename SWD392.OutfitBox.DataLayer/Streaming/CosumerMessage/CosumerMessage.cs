using Confluent.Kafka;
using FirebaseAdmin.Messaging;
using Newtonsoft.Json;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Streaming.ProducerMessage;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Streaming.CosumerMessage
{
    public class CosumerBrandMessage
    {
        public static async Task<Message<Brand>> ProcessMessageSetValueRedis(CancellationToken cancellationToken)
        {
            Message<Brand> lastMessage = null;

            using (var c = new ConsumerBuilder<Ignore, string>(Config.GetConsumerConfig()).Build())
            {
                c.Subscribe("Brands");

                try
                {
                    c.Assign(c.Assignment);
                    foreach (var partition in c.Assignment)
                    {
                        c.Seek(new TopicPartitionOffset(partition.Topic, partition.Partition, Offset.End));
                    }

                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var cr = c.Consume(cancellationToken);

                        if (cr.Value != null) c.Commit(cr);
                        Console.WriteLine($"Consumed message '{cr?.Value}' at: '{cr.TopicPartitionOffset}'.");

                        lastMessage = JsonConvert.DeserializeObject<Message<Brand>>(cr.Value);
                        return lastMessage;
                    }
                }
                catch (ConsumeException e)
                {
                    throw new Exception(e.Message);
                }
                catch (OperationCanceledException)
                {

                }
                finally
                {
                    c.Close();
                }
            }

            return lastMessage;
        }
        public static async Task<Message<List<Brand>>> ProcessMessageSetListValueRedis(CancellationToken cancellationToken)
        {
            Message<List<Brand>> lastMessage = null;

            using (var c = new ConsumerBuilder<Ignore, string>(Config.GetConsumerConfig()).Build())
            {
                c.Subscribe("List-Brands");

                try
                {
                    c.Assign(c.Assignment);
                    foreach (var partition in c.Assignment)
                    {
                        c.Seek(new TopicPartitionOffset(partition.Topic, partition.Partition, Offset.End));
                    }

                    while (!cancellationToken.IsCancellationRequested)
                    {
                        try
                        {
                            var cr = c.Consume(cancellationToken);
                            if (cr.Value != null) c.Commit(cr);
                            Console.WriteLine($"Consumed message '{cr?.Value}' at: '{cr.TopicPartitionOffset}'.");

                            lastMessage = JsonConvert.DeserializeObject<Message<List<Brand>>>(cr.Value);
                            return lastMessage;
                        }
                        catch (ConsumeException e)
                        {
                            Console.WriteLine($"Error occurred: {e.Error.Reason}");
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // Expected exception on shutdown, no need to handle
                }
                finally
                {
                    c.Close();
                }
            }

            return lastMessage;
        }
        public static async Task<Message<Category>> ProcessCategoryMessageSetValueRedis(CancellationToken cancellationToken)
        {
            Message<Category> lastMessage = null;

            using (var c = new ConsumerBuilder<Ignore, string>(Config.GetConsumerConfig()).Build())
            {
                c.Subscribe("Categories");

                try
                {
                    c.Assign(c.Assignment);
                    foreach (var partition in c.Assignment)
                    {
                        c.Seek(new TopicPartitionOffset(partition.Topic, partition.Partition, Offset.End));
                    }

                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var cr = c.Consume(cancellationToken);

                        if (cr.Value != null) c.Commit(cr);
                        Console.WriteLine($"Consumed message '{cr?.Value}' at: '{cr.TopicPartitionOffset}'.");

                        lastMessage = JsonConvert.DeserializeObject<Message<Category>>(cr.Value);
                        return lastMessage;
                    }
                }
                catch (ConsumeException e)
                {
                    throw new Exception(e.Message);
                }
                catch (OperationCanceledException)
                {

                }
                finally
                {
                    c.Close();
                }
            }


            return lastMessage;
        }

        public static async Task<Message<List<Category>>> ProcessListCategoryMessageSetValueRedis(CancellationToken cancellationToken)
        {
            Message<List<Category>> lastMessage = null;

            using (var c = new ConsumerBuilder<Ignore, string>(Config.GetConsumerConfig()).Build())
            {
                c.Subscribe("List-Categories");

                try
                {
                    c.Assign(c.Assignment);
                    foreach (var partition in c.Assignment)
                    {
                        c.Seek(new TopicPartitionOffset(partition.Topic, partition.Partition, Offset.End));
                    }

                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var cr = c.Consume(cancellationToken);

                        if (cr.Value != null) c.Commit(cr);
                        Console.WriteLine($"Consumed message '{cr?.Value}' at: '{cr.TopicPartitionOffset}'.");

                        lastMessage = JsonConvert.DeserializeObject<Message<List<Category>>>(cr.Value);
                        return lastMessage;
                    }
                }
                catch (ConsumeException e)
                {
                    throw new Exception(e.Message);
                }
                catch (OperationCanceledException)
                {

                }
                finally
                {
                    c.Close();
                }
            }
            return lastMessage;
        }
        public static async Task<(Message, CustomerPackage)> ProcessMessageNotification(CancellationToken cancellationToken)
        {
            Message<CustomerPackage> lastMessage = null;

            using (var c = new ConsumerBuilder<Ignore, string>(Config.GetConsumerConfig()).Build())
            {
                c.Subscribe("Notifications-User");

                try
                {
                    c.Assign(c.Assignment);
                    foreach (var partition in c.Assignment)
                    {
                        c.Seek(new TopicPartitionOffset(partition.Topic, partition.Partition, Offset.End));
                    }

                    while (!cancellationToken.IsCancellationRequested)
                    {
                        try
                        {
                            var cr = c.Consume(cancellationToken);
                            if (cr.Value != null) c.Commit(cr);
                            Console.WriteLine($"Consumed message '{cr?.Value}' at: '{cr.TopicPartitionOffset}'.");

                            lastMessage = JsonConvert.DeserializeObject<Message<CustomerPackage>>(cr.Value);
                            return (new Message()
                            {
                                Notification = new Notification()
                                {
                                    Title = $"Return Money In Order #{lastMessage.Data.Id}",
                                    Body = $"Thank you for using our services, your deposit in order #{lastMessage.Data.Id} is returned successfully. The money is {lastMessage.Data.ReturnDeposit}",
                                },
                            }, lastMessage.Data);
                        }
                        catch (ConsumeException e)
                        {
                            Console.WriteLine($"Error occurred: {e.Error.Reason}");
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // Expected exception on shutdown, no need to handle
                }
                finally
                {
                    c.Close();
                }
            }

            return (new Message()
            {
            }, new CustomerPackage());
        }

        public static async Task<Message<TEntity>> ProcessMessageSetValueRedis<TEntity> (CancellationToken cancellationToken) where TEntity: class
        {
            Message<TEntity> lastMessage = null;

            using (var c = new ConsumerBuilder<Ignore, string>(Config.GetConsumerConfig()).Build())
            {
                c.Subscribe("Redis-UpdateData");

                try
                {
                    c.Assign(c.Assignment);
                    foreach (var partition in c.Assignment)
                    {
                        c.Seek(new TopicPartitionOffset(partition.Topic, partition.Partition, Offset.End));
                    }

                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var cr = c.Consume(cancellationToken);

                        if (cr.Value != null) c.Commit(cr);
                        Console.WriteLine($"Consumed message '{cr?.Value}' at: '{cr.TopicPartitionOffset}'.");

                        lastMessage = JsonConvert.DeserializeObject<Message<TEntity>>(cr.Value);
                        return lastMessage;
                    }
                }
                catch (ConsumeException e)
                {
                    throw new Exception(e.Message);
                }
                catch (OperationCanceledException)
                {

                }
                finally
                {
                    c.Close();
                }
            }

            return lastMessage;
        }

    }
}
