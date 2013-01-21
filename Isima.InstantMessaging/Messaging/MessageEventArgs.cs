using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isima.InstantMessaging.Messaging
{
    public class MessageEventArgs : EventArgs
    {
        private Message mess;

        public Message Mess
        {
            get { return mess; }
            set { mess = value; }
        }
    }
}
