using Confluent.Kafka;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Newtonsoft.Json;
using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Streaming.ProducerMessage
{
    public class ProducerMessage
    {   
        public ProducerMessage() { }

        public static async Task ProductBrandMessage(string messageContent,string command, Brand entity, string key)
        {
            var message = new Message<Brand>()
            {
                Command = command,
                Data = entity,
                MessageContent = messageContent,
                Key=key
            };
            var serializedMessage = JsonConvert.SerializeObject(message);
            using (var p = new ProducerBuilder<Null, string>(Config.GetProducerConfig()).Build())
            {
                try
                {
                    var dr = await p.ProduceAsync("Brands", new Message<Null, string> { Value = serializedMessage, Timestamp = Timestamp.Default, Key = null, });
                    Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }
        }
        public static async Task ProductListBrandMessage(string messageContent, string command, List< Brand> entity, string key)
        {
            var message = new Message<List<Brand>>()
            {
                Command = command,
                Data = entity,
                MessageContent = messageContent,
                Key = key
            };
            var serializedMessage = JsonConvert.SerializeObject(message);
            using (var p = new ProducerBuilder<Null, string>(Config.GetProducerConfig()).Build())
            {
                try
                {
                    var dr = await p.ProduceAsync("List-Brands", new Message<Null, string> { Value = serializedMessage, Timestamp = Timestamp.Default, Key = null, });
                    Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }
        }
    }
    public class Message<T> where T : class
    {   
        public string? MessageContent { get; set; }
        public string? Key { get; set; }
        public string? Command {  get; set; } 
        public T? Data { get; set; }

    }
}
