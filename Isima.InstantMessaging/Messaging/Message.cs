﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isima.InstantMessaging.Messaging
{
    public class Message
    {
        public string SenderAddress { get; set; }
        public string ReceiverAddress { get; set; }
        public DateTime Instant { get; set; }
        public string Content { get; set; }
    }
}
