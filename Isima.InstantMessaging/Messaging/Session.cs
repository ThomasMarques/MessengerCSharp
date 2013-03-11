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
            Available,
            Buzy,
            Absent,
            Offligne
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

        public bool Equals(Session o)
        {
            return Identifiant.Equals(o.Identifiant);
        }
    }
}
