using RoomService.Domain.BidDto;
using RoomService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomService.Core.Abstraction
{
    public interface IBidService
    {
            Task SendBidAsync(BidDto model);
        
    }
}
