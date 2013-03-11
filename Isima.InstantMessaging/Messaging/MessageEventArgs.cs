using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isima.InstantMessaging.Messaging
{
    public class MessageEventArgs : EventArgs
    {
        public MessageEventArgs(Message messageData)
        {
            this.MessageData = messageData;
        }

        public Message MessageData { get; set; }
    }
}
