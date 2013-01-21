using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Isima.InstantMessaging.Messaging
{


    public class SessionController
    {
        private event EventHandler _sendMessageEvent;

        public event EventHandler MessageReceived;


        public SessionController()
        {
            
        }
        
        public void initialize()
        {
            Thread.Sleep(10);
        }

        public void send(Message mess)
        {
            Thread.Sleep(5);
            String tmp = mess.ReceiverAdress;

            mess.ReceiverAdress = mess.SenderAdress;
            mess.SenderAdress = tmp;
            mess.Content = "Echo : " + mess.Content;

            MessageEventArgs mea = new MessageEventArgs();
            mea.Mess = mess;
            //_sendMessageEvent(this, mea);
        }
    }
}
