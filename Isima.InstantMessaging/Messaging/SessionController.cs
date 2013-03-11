using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isima.InstantMessaging.Messaging
{
    public class SessionController
    {
        public event EventHandler<MessageEventArgs> MessageReceived;

        public void Initialize()
        {
            // Simulate the initialization of a session by waiting 5 seconds.
            System.Threading.Thread.Sleep(10000);
        }

        public void Send(Message message)
        {
            // Simulate a conference by waiting 5 seconds prior to sending a response
            System.Threading.Thread.Sleep(5000);
            Message echo = new Message()
            {
                SenderAddress = message.ReceiverAddress,
                ReceiverAddress = message.SenderAddress,
                Content = string.Concat("Echo: ", message.Content),
                Instant = DateTime.Now
            };
            OnMessageReceived(echo);
        }

        private void OnMessageReceived(Message messageData)
        {
            if (MessageReceived != null)
            {
                MessageReceived(this, new MessageEventArgs(messageData));
            }
        }
    }
}
