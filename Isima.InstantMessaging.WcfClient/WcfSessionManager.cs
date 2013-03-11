using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Isima.InstantMessaging.Session;
using Isima.InstantMessaging.Messaging;

namespace Isima.InstantMessaging.WcfClient
{
    public class WcfSessionManager : ISessionManager
    {
        public void Send(Message message)
        {
            //identique avec session au lieu de contact
            using (SessionServiceReference.SessionServiceClient service = new SessionServiceReference.SessionServiceClient())
            {
                SessionServiceReference.Message mess = new SessionServiceReference.Message();
                mess.ReceiverAddress = message.ReceiverAddress;
                mess.SenderAddress = message.SenderAddress;
                mess.Content = message.Content;
                mess.Instant = message.Instant;
                service.SendMessage(mess);

            }
        }
    }
}
