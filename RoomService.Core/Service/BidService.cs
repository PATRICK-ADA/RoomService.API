
using Newtonsoft.Json;
using RoomService.Core.Abstraction;
using RoomService.Domain.BidDto;
using Serilog;
using BidService.API.BidService.Domain.Entities;
using RoomService.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using RoomService.Domain.UserDto;

namespace RoomService.Core.Services
{

    public class BidService : IBidService
    {

        private readonly IKafKaPublisherService _producer;
        private readonly IBidRepository _bidRepository;
        private readonly UserManager<UserModel> _userManager;





        public BidService(IKafKaPublisherService producer, IBidRepository bidRepository, UserManager<UserModel> userManager)
        {
            _producer = producer;
            _bidRepository = bidRepository;
            _userManager = userManager; 
        }

        public async Task SendBidAsync(BidDto model)
        {

          
            if (model.UserName is null || model.Cars is null || model.AmountPaid < 1)
            { 
            
                Log.Error("Invalid bid details provided");
                throw new ArgumentNullException("All fields are required fields");
            }

            var Null = new UserModel()
            {
                UserName = "Dummy value"
            };
            var result = await _userManager.FindByNameAsync(model.UserName);
            var handleNull = result ?? Null;
            if (handleNull.UserName != model.UserName)
            {
                Log.Error("UserNAme must match a UserName of a registered Bidder");
                throw new ArgumentNullException("UserName is incorrect");
            }

                var bidMessage = new BidModel();

                bidMessage.UserName = model.UserName;
                bidMessage.Cars = model.Cars;
                bidMessage.AmountPaid = model.AmountPaid;
                bidMessage.Id = Guid.NewGuid();


                var message = JsonConvert.SerializeObject(bidMessage);


                try
                {
                    Log.Information($"Sending bid message to Kafka: {bidMessage}");

                    await _producer.ProduceAsync(bidMessage.Id, message);
                    Log.Information("Bid message sent successfully to Kafka");

                    await _bidRepository.SaveBidEntories(model);
                    Log.Information("Bid entry saved successfully");

                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error occurred while sending bid to Kafka");
                    throw;
                }

            
        }

      
    }
}
