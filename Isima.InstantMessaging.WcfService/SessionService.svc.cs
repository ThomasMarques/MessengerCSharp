﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace Isima.InstantMessaging.WcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "SessionService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez SessionService.svc ou SessionService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class SessionService : ISessionService
    {

        private static TimeSpan expirationSpan = new TimeSpan(0, 1, 0);

        private static IList<Session> _sessions = new List<Session>();
        private static IDictionary<string, List<Message>> _messages = new Dictionary<string, List<Message>>();

        public Session Register()
        {
            String name = "public";

            // On récupère la date du client
            DateTime current = DateTime.Now;

            if (!OperationContext.Current.ServiceSecurityContext.IsAnonymous)
                name = Text.Sanitizer.SanitizeFileName(OperationContext.Current.ServiceSecurityContext.WindowsIdentity.Name);

            Session session = new Session();
            session.Identifiant = System.Guid.NewGuid();
            session.WindowsIdentityName = name;
            session.Expiration = current += expirationSpan;
            session.CurrentEtat = Etat.Available;

            _sessions.Add(session);

            return session;
        }

        public Session ReRegister(System.Guid identifiant)
        {
            String name = "public";
            Session ret = null;

            if (!OperationContext.Current.ServiceSecurityContext.IsAnonymous)
                name = Text.Sanitizer.SanitizeFileName(OperationContext.Current.ServiceSecurityContext.WindowsIdentity.Name);

            // On récupère la date du client
            DateTime current = DateTime.Now;

            Session session = new Session();
            session.Identifiant = identifiant;

            //int index = _sessions.IndexOf(session);
            int index = -1;
            int i = 0;
            foreach (Session s in _sessions)
            {
                if (s.Identifiant.Equals(identifiant))
                {
                    index = i;
                }
                else i++;
            }

            if (index != -1)
            {
                ret = _sessions.ElementAt(index);
                if(ret.WindowsIdentityName.Equals(name))
                {
                    ret.Expiration = current + expirationSpan;
                }
                else
                {
                    ret = null;
                }
            }

            return ret;
        }

        public Etat GetPresence(String windowsIdentityName)
        {
            foreach (Session s in _sessions)
            {
                if (s.WindowsIdentityName.Equals(windowsIdentityName))
                {
                    return s.CurrentEtat;
                }
            }

            return Etat.Offligne;
        }

        public Session setEtat(Etat etat)
        {
            String name = "public";

            if (!OperationContext.Current.ServiceSecurityContext.IsAnonymous)
                name = Text.Sanitizer.SanitizeFileName(OperationContext.Current.ServiceSecurityContext.WindowsIdentity.Name);

            foreach (Session s in _sessions)
            {
                if(s.WindowsIdentityName.Equals(name))
                {
                    s.CurrentEtat = etat;
                    return s;
                }
            }

            return null;
        }

        public void SendMessage(Message message)
        {
            Etat ret = GetPresence(message.ReceiverAddress);

            //enregistre le message dans la map
            if (!_messages.Keys.Contains(message.ReceiverAddress))
            {
                _messages.Add(message.ReceiverAddress, new List<Message>());
            }

            _messages[message.ReceiverAddress].Add(message);
        }

        public List<Message> GetMessage(string adresse)
        {
            List<Message> ret = new List<Message>(_messages[adresse]);

            _messages[adresse].Clear();

            return ret;
        }

    }
}
