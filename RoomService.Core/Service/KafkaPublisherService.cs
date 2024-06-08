using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using RoomService.Core.Abstraction;
using Serilog;

namespace ServiceRoom.core.service
{
    public class KafkaPublisherService : IKafKaPublisherService
    {
        private readonly IProducer<string, string> _producer;
        private readonly string _topic;

        public KafkaPublisherService(IConfiguration configuration)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"],
                SaslMechanism = SaslMechanism.Plain,
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslUsername = configuration["kafka:SaslUsername"],
                SaslPassword = configuration["kafka:SaslPassword"]
            };

            _producer = new ProducerBuilder<string, string>(config).Build();
            _topic = configuration["Kafka:Topic"];
        }

        public async Task ProduceAsync(Guid key, string value)
        {
            var message = new Message<string, string> { Key = key.ToString(), Value = value };
            var deliveryResult = await _producer.ProduceAsync(_topic, message);

            
            Log.Information($"Delivered '{deliveryResult.Value}' to '{deliveryResult.TopicPartitionOffset}'");
        }
    }
}

