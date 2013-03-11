using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Isima.InstantMessaging.WcfService
{
    [ServiceContract]
    public interface IContactService
    {
        [OperationContract]
        IList<Contact> List();

        [OperationContract]
        void Save(IList<Contact> contacts);
    }
}
