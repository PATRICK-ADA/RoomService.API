﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomService.Core.Abstraction
{
    public interface IKafkaConsumerService
    {
        void Consume(CancellationToken cancellationToken);
    }
}
