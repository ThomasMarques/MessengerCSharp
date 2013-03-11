using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Isima.InstantMessaging.WcfService
{
    [DataContract]
    public class Session
    {
        [DataMember]
        public System.Guid Identifiant { get; set; }

        [DataMember]
        public DateTime Expiration { get; set; }

        [DataMember]
        public String WindowsIdentityName { get; set; }

        public bool Equals(Object o)
        {
            bool ret = false;
            if (o.GetType().Equals(this.GetType()))
                ret = Equals(o as Session);
            return ret;
        }

        public bool Equals(Session o)
        {
            return Identifiant.Equals(o.Identifiant);
        }
    }
}