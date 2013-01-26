using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isima.InstantMessaging.Messaging
{
    public class MessageEventArgs : EventArgs
    {
        /// <summary>
        /// Message à envoyer.
        /// </summary>
        private Message _mess;

        /// <summary>
        /// <see cref="_mess"/>
        /// </summary>
        public Message Mess
        {
            get { return _mess; }
            set { _mess = value; }
        }
    }
}
