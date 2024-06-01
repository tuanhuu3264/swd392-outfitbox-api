﻿using Confluent.Kafka;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Infrastructure.Streaming.ProducerMessage
{
    public class ProducerMessage
    {
        public ProducerMessage() { }

        public async Task ProductMessage(string message, Product product)
        {
            if (message == null) return;
            using (var p = new ProducerBuilder<Null, Product>(Config.GetProducerConfig()).Build())
            {
                try
                {
                    var dr = await p.ProduceAsync(nameof(Product)+"s", new Message<Null, Product> { Value = product});
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
