using System;
using System.Web;
using System.Runtime.Serialization;

namespace Isima.InstantMessaging.WcfService
{
    [DataContract]
    public class Contact
    {
        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string DisplayName { get; set; }
    }
}