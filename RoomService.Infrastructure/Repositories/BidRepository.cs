using BidService.API.BidService.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RoomService.Core.Abstraction;
using RoomService.Core.ApiResponse;
using RoomService.Domain.BidDto;
using RoomService.Infrastructure.Data;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RoomService.Infrastructure.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly AppDbContext _Context;

        public BidRepository(AppDbContext Context )
        {
           _Context = Context;

        }
            
        
        public async Task SaveBidEntories(BidDto model)
        {
            if (model is null)
            {
                throw new ArgumentNullException("No Bid details found");
            }
            var bidMessage = new BidModel();

            bidMessage.UserName = model.UserName;
            bidMessage.Cars = model.Cars;
            bidMessage.AmountPaid = model.AmountPaid;
            bidMessage.Id = Guid.NewGuid();

            await _Context.RoomBidders.AddAsync(bidMessage);
            await _Context.SaveChangesAsync();
           

        }

    }
}
