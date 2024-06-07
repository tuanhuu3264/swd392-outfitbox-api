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

        public async Task ProductMessage(string message, Product product)
        {
            if (message == null) return;
            using (var p = new ProducerBuilder<Null, string>(Config.GetProducerConfig()).Build())
            {
                try
                {
                    var dr = await p.ProduceAsync(nameof(Product)+"s", new Message<Null, string> { Value = "Aslo"});
                    Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }
        }
    }
}
