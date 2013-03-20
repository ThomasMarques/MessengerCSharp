using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Isima.InstantMessaging.Session;
using Isima.InstantMessaging.Messaging;
using System.Timers;

namespace Isima.InstantMessaging.WcfClient
{
    public class WcfSessionManager : ISessionManager
    {
        private Messaging.Session currentSession;

        public void Ping(object source, ElapsedEventArgs e)
        {
            using (SessionServiceReference.SessionServiceClient service = new SessionServiceReference.SessionServiceClient())
            {
                SessionServiceReference.Session session = service.Register(currentSession.Identifiant);

                //Attention il manque des attributs
                currentSession.Expiration = session.Expiration;
            }
        }

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

        public void Receive(object source, ElapsedEventArgs e)
        {
            if (source is SessionController)
            {
                string senderAddress = currentSession.WindowsIdentityName;

                using (SessionServiceReference.SessionServiceClient service = new SessionServiceReference.SessionServiceClient())
                {
                    SessionServiceReference.Message[] listMess = service.GetMessage(senderAddress);

                    foreach (SessionServiceReference.Message mess in listMess)
                    {
                        Message newMess = new Message
                        {
                            Content = mess.Content,
                            Instant = mess.Instant,
                            ReceiverAddress = mess.ReceiverAddress,
                            SenderAddress = mess.SenderAddress
                        };

                        (source as SessionController).OnMessageReceived(newMess);
                    }
                }
            }
        }

        public void Register()
        {
            using (SessionServiceReference.SessionServiceClient service = new SessionServiceReference.SessionServiceClient())
            {
                SessionServiceReference.Session session = service.Register();

                //Attention il manque des attributs
                currentSession = new Messaging.Session()
                {
                    Expiration = session.Expiration,
                    Identifiant = session.Identifiant,
                    WindowsIdentityName = session.WindowsIdentityName
                };
            }
        }
    }
}
