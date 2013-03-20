using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Isima.InstantMessaging.Messaging;
using Isima.InstantMessaging.Contacts;

namespace Isima.InstantMessaging.WindowsClient
{
    public class MessagingContext
    {
        private static MessagingContext singleton;
        private static object singletongSyncRoot = new object();

        private MessagingContext()
        {
            this.MessagingSessionController = new SessionController(SenderAddress);
            this.ContactsManager = new WcfClient.WcfContactsManager();
        }

        static public MessagingContext Current
        {
            get
            {
                lock (singletongSyncRoot)
                {
                    if (singleton == null)
                        singleton = new MessagingContext();
                }
                return singleton;
            }
        }

        public IContactsManager ContactsManager { get; private set; }
        public SessionController MessagingSessionController { get; private set; }
        public string SenderAddress { get; set; }
    }
}
