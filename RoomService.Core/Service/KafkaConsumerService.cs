using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RoomService.Core.Abstraction;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomService.Core.Service
{
   /* public class KafkaConsumerService : BackgroundService
    {
        private readonly IConsumer<string, string> _consumer;

        public KafkaConsumerService(IConfiguration configuration)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"],
                SaslMechanism = SaslMechanism.Plain,
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslUsername = configuration["Kafka:ApiKey"],
                SaslPassword = configuration["Kafka:Secret"],
                GroupId = configuration["Kafka:GroupId"],
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _consumer = new ConsumerBuilder<string, string>(config).Build();
            _consumer.Subscribe(configuration["Kafka:Topic"]);
        }

        public void Consume(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var consumeResult = _consumer.Consume(cancellationToken);

                   
                    Log.Information($"Consumed message '{consumeResult.Message.Value}' at: '{consumeResult.TopicPartitionOffset}'.");

                    
                    _consumer.Commit(consumeResult);
                }
            }
            catch (OperationCanceledException)
            {
                
            }
            finally
            {
                _consumer.Close();
            }
        }
    }
*/
}