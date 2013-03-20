using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Isima.InstantMessaging.Messaging;

namespace Isima.InstantMessaging.WcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "ISessionService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface ISessionService
    {
        [OperationContract]
        bool SendMessage(Message message);

        [OperationContract]
        List<Message> GetMessage(string adresse);

        [OperationContract]
        Session Register(DateTime current);

        [OperationContract]
        bool GetPresence(String windowsIdentityName);
    }
}
