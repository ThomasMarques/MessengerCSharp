using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isima.InstantMessaging.Messaging
{
    public class Message
    {
        /// <summary>
        /// Addresse de l'expéditeur.
        /// </summary>
        private String _senderAdress;

        /// <summary>
        /// <see cref="_senderAdress"/>
        /// </summary>
        public String SenderAdress
        {
            get { return _senderAdress; }
            set { _senderAdress = value; }
        }

        /// <summary>
        /// Addresse du destinataire.
        /// </summary>
        private String _receiverAdress;

        /// <summary>
        /// <see cref="_receiverAdress"/>
        /// </summary>
        public String ReceiverAdress
        {
            get { return _receiverAdress; }
            set { _receiverAdress = value; }
        }

        /// <summary>
        /// Date et heure de l'envoi.
        /// </summary>
        private DateTime _instant;

        /// <summary>
        /// <see cref="_instant"/>
        /// </summary>
        public DateTime Instant
        {
            get { return _instant; }
            set { _instant = value; }
        }

        /// <summary>
        /// Contenu du message.
        /// </summary>
        private String _content;

        /// <summary>
        /// <see cref="_content"/>
        /// </summary>
        public String Content
        {
            get { return _content; }
            set { _content = value; }
        }

        /// <summary>
        /// Permet de construire un message.
        /// </summary>
        /// <param name="senderAddress">Addresse de l'expéditeur.</param>
        /// <param name="recAdress">Addresse du destinataire.</param>
        /// <param name="contenu">Contenue du messae</param>
        public Message(String senderAddress, String recAdress, String contenu)
        {
            _senderAdress = senderAddress;
            _receiverAdress = recAdress;
            _content = contenu;
            _instant = DateTime.Now;
        }
    }
}
