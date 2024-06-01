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
        BootstrapServers = "<your-IP-port-pairs>",
        SecurityProtocol = SecurityProtocol.SaslPlaintext,
        SaslMechanism = SaslMechanism.ScramSha256,
        SaslUsername = "ickafka",
        SaslPassword = "yourpassword"
    };

    public static ConsumerConfig GetConsumerConfig() => new ConsumerConfig
    {
        GroupId = "test-consumer-group",
        BootstrapServers = "<your-IP-port-pairs>",
        SslCaLocation = "/PathTO/cluster-ca-certificate.pem",
        SecurityProtocol = SecurityProtocol.SaslSsl,
        SaslMechanism = SaslMechanism.ScramSha256,
        SaslUsername = "ickafka",
        SaslPassword = "yourpassword",
        AutoOffsetReset = AutoOffsetReset.Latest,
    };
}
