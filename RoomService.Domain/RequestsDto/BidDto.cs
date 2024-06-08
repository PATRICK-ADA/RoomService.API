
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomService.Domain.BidDto
{
    public class BidDto
    {
        public string UserName { get; set; } = null!;
        public List<string> Cars { get; set; } = null!;
        public decimal AmountPaid { get; set; }


    }
}
