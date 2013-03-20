using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Isima.InstantMessaging.WcfService
{
    [DataContract]
    public class Message
    {
        [DataMember]
        public string SenderAddress { get; set; }
        [DataMember]
        public string ReceiverAddress { get; set; }
        [DataMember]
        public DateTime Instant { get; set; }
        [DataMember]
        public string Content { get; set; }
    }
}