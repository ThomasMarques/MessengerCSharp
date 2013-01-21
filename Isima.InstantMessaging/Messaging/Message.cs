using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isima.InstantMessaging.Messaging
{
    public class Message
    {
        private String _senderAdress;
        private Base64Encoder _base64;
        private Sanitizer _sani;

        public String SenderAdress
        {
            get { return _senderAdress; }
            set { _senderAdress = value; }
        }
        private String _receiverAdress;

        public String ReceiverAdress
        {
            get { return _receiverAdress; }
            set { _receiverAdress = value; }
        }
        private DateTime _instant;

        public DateTime Instant
        {
            get { return _instant; }
            set { _instant = value; }
        }
        private String _content;

        public String Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public Message(String senderAddress, String rec, String cont)
        {
            _sani = new Sanitizer();
            _base64 = new Base64Encoder();

            _senderAdress = senderAddress;
            _receiverAdress = rec;
            _content = _sani.Sanitize(_sani.NeutralizeUrl(cont));
            _instant = DateTime.Now;
        }
    }
}
