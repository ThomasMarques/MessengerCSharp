using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Isima.InstantMessaging.Messaging;

namespace Isima.InstantMessaging.Session
{
    public interface ISessionManager
    {
        void Send(Message message);
    }
}
