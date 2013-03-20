using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Isima.InstantMessaging.Messaging;
using System.Timers;

namespace Isima.InstantMessaging.Session
{
    public interface ISessionManager
    {
        void Send(Message message);

        void Ping(object source, ElapsedEventArgs e);

        void Receive(object source, ElapsedEventArgs e);

        void Register();
    }
}
