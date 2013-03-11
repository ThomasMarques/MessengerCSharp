using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isima.InstantMessaging.Messaging
{
    public class Session
    {
        public System.Guid Identifiant { get; set; }

        public DateTime Expiration  { get; set; }

        public String WindowsIdentityName { get; set; }
    }
}
