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
            using (ContactServiceReference.ContactServiceClient client = new ContactServiceReference.ContactServiceClient())
            {

            }
        }
    }
}
