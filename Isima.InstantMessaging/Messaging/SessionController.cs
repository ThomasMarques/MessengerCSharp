using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Isima.InstantMessaging.Messaging
{


    public class SessionController
    {
        /// <summary>
        /// Addresse mail de l'utilisateur.
        /// </summary>
        public static readonly String MY_NAME = "monAdresse@gmail.com";

        /// <summary>
        /// Evenement envoyé lors pour envoyé un message.
        /// </summary>
        public event EventHandler<MessageEventArgs> _sendMessageEvent;

        /// <summary>
        /// Instance unique de la classe. (Singleton)
        /// </summary>
        private static SessionController _instance;

        /// <summary>
        /// Constructeur privé. (Singleton)
        /// </summary>
        private SessionController()
        {
            
        }

        /// <summary>
        /// Permet de récupérer une instance de la classe et de la créer si besoin. (Singleton)
        /// </summary>
        /// <returns>Une instance de la classe</returns>
        public static SessionController GetInstance()
        {
            if (_instance == null)
                _instance = new SessionController();
            return _instance;
        }
        
        /// <summary>
        /// Permet d'initialiser une conversation.
        /// </summary>
        public void initialize()
        {
            Thread.Sleep(10000);
        }

        /// <summary>
        /// Permet d'envoyer un message.
        /// </summary>
        /// <param name="mess">Le message à envoyer.</param>
        public void send(Message mess)
        {
            Thread.Sleep(5000);
            String tmp = mess.ReceiverAdress;

            mess.ReceiverAdress = mess.SenderAdress;
            mess.SenderAdress = tmp;
            mess.Content = "Echo : " + mess.Content;

            MessageEventArgs mea = new MessageEventArgs();
            mea.Mess = mess;

            if(_sendMessageEvent != null)
                _sendMessageEvent(this, mea);
        }
    }
}
