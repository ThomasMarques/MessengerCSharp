using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Isima.InstantMessaging.Session;

namespace Isima.InstantMessaging.Messaging
{
    public class SessionController
    {

        public SessionController(string add)
        {
            myAddress = add;
        }

        public string MyAddress
        {
            get { return myAddress; }
        }
        private string myAddress;

        private const int RECEIVE_SPAN = 10000;
        private const int PING_SPAN = 3000;

        public event EventHandler<MessageEventArgs> MessageReceived;

        private ISessionManager currentSessionManager;

        public void Initialize(ISessionManager curentSessM)
        {
            currentSessionManager = curentSessM;
            // Simulate the initialization of a session by waiting 5 seconds.
            currentSessionManager.Register();
            StartReceive();
            StartPing();
        }

        public void Send(Message message)
        {
            // Simulate a conference by waiting 5 seconds prior to sending a response
            /*System.Threading.Thread.Sleep(5000);
            Message echo = new Message()
            {
                SenderAddress = message.ReceiverAddress,
                ReceiverAddress = message.SenderAddress,
                Content = string.Concat("Echo: ", message.Content),
                Instant = DateTime.Now
            };
            OnMessageReceived(echo);*/

            //appel la méthode send du webservice
            ISessionManager sessionManager = currentSessionManager;
            currentSessionManager.Send(message);
        }

        public void StartReceive()
        {
            ISessionManager sessionManager = currentSessionManager;

            System.Timers.Timer aTimer = new System.Timers.Timer(RECEIVE_SPAN);
            aTimer.Elapsed += new System.Timers.ElapsedEventHandler(currentSessionManager.Receive);
            aTimer.Enabled = true;
        }

        public void StartPing()
        {
            ISessionManager sessionManager = currentSessionManager;

            System.Timers.Timer aTimer = new System.Timers.Timer(PING_SPAN);
            aTimer.Elapsed += new System.Timers.ElapsedEventHandler(currentSessionManager.Ping);
            aTimer.Enabled = true;
        }

        public void OnMessageReceived(Message messageData)
        {
            if (MessageReceived != null)
            {
                MessageReceived(this, new MessageEventArgs(messageData));
            }
        }
    }
}
