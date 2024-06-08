using Microsoft.AspNetCore.Mvc;
using RoomService.Core.Abstraction;
using RoomService.Domain.BidDto;


namespace RoomService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BidsController: ControllerBase
    {

        private readonly IBidService _bidService;

        public BidsController(IBidService bidService)
        {
            _bidService = bidService;
        }

        [HttpPost("sendBidsToKafka")]
        public async Task<IActionResult> SendBid([FromBody] BidDto model)
        {
           await _bidService.SendBidAsync(model);
            return Ok(new { Result = "Bid sent successfully" });
        }
    }



}

