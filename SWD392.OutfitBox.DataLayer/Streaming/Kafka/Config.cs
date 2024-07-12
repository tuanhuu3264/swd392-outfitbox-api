using System;
using System.Threading.Tasks;
using Confluent.Kafka;

public class Config
{
    public Config()
    {

    }
    public static ProducerConfig GetProducerConfig() => new ProducerConfig
    {  
        BootstrapServers = "34.123.203.83:9092",
    };

    public static ConsumerConfig  GetConsumerConfig() => new ConsumerConfig
    {
        EnableAutoCommit = true,
        AutoOffsetReset = AutoOffsetReset.Earliest,
        GroupId = "Node-1",
        BootstrapServers = "34.123.203.83:9092",
    };
}
