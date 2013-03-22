using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isima.InstantMessaging.Messaging
{
    public class Session : IComparable 
    {
        public enum Etat
        {
            Away,
            Buzy,
            Absent,
            Disconnect
        };

        public System.Guid Identifiant { get; set; }

        public DateTime Expiration { get; set; }

        public String WindowsIdentityName { get; set; }

        public Etat CurrentEtat { get; set; }

        public override bool Equals(Object o)
        {
            bool ret = false;
            if (o.GetType().Equals(this.GetType()))
                ret = Equals(o as Session);
            return ret;
        }

        public int CompareTo(Object o)
        {
            return 0;
        }

        public bool Equals(Session o)
        {
            return Identifiant.Equals(o.Identifiant);
        }

        public override int GetHashCode() 
        {
            return (this as object).GetHashCode();
        }

    }
}
