using KafkaFlow;
using Serilog;

namespace RoomService.API.Extensions
{
        public class MessageHandler : IMessageHandler<string>
        {
            public Task Handle(IMessageContext context, string message)
            {
                // Process the message
                Log.Information($"Received message: {message}");
                return Task.CompletedTask;
            }
        }
    
}
