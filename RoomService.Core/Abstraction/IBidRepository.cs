using RoomService.Domain.BidDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomService.Core.Abstraction
{
    public interface IBidRepository
    {
        Task SaveBidEntories(BidDto Bids);
      
    }
}
