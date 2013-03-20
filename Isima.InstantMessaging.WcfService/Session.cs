using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Isima.InstantMessaging.WcfService
{
    public enum Etat
    {
        Available,
        Buzy,
        Absent,
        Offligne
    };

    [DataContract]
    public class Session : IComparable 
    {

        [DataMember]
        public System.Guid Identifiant { get; set; }

        [DataMember]
        public DateTime Expiration { get; set; }

        [DataMember]
        public String WindowsIdentityName { get; set; }

        [DataMember]
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
    }
}