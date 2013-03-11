using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Isima.InstantMessaging.WcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "ISessionService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface ISessionService
    {
        [OperationContract]
        Session Register(DateTime current);

        [OperationContract]
        bool GetPresence(String windowsIdentityName)
    }
}
