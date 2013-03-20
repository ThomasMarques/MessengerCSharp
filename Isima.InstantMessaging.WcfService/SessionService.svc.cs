using System;
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

        private IList<Session> _sessions = new List<Session>();
        private IDictionary<string, List<Message>> _messages = new Dictionary<string, List<Message>>();

        public Session Register(DateTime current)
        {
            String name = "public";

            if (!OperationContext.Current.ServiceSecurityContext.IsAnonymous)
                name = Text.Sanitizer.SanitizeFileName(OperationContext.Current.ServiceSecurityContext.WindowsIdentity.Name);

            Session session = new Session();
            session.Identifiant = System.Guid.NewGuid();
            session.WindowsIdentityName = name;
            session.Expiration = current += expirationSpan;

            _sessions.Add(session);

            return session;
        }

        public bool GetPresence(String windowsIdentityName)
        {
            Session s = new Session();
            s.WindowsIdentityName = windowsIdentityName;
            return _sessions.Contains(s);
        }

        public bool SendMessage(Message message)
        {
            bool ret = GetPresence(message.ReceiverAddress);

            //enregistre le message dans la map
            if (!_messages.Keys.Contains(message.ReceiverAddress))
            {
                _messages.Add(message.ReceiverAddress, new List<Message>());
            }

            _messages[message.ReceiverAddress].Add(message);

            return ret;
        }

        public List<Message> GetMessage(string adresse)
        {
            List<Message> ret = new List<Message>(_messages[adresse]);

            _messages[adresse].Clear();

            return ret;
        }
    }
}
