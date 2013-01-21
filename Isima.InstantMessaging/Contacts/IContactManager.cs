using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isima.InstantMessaging.Contacts
{
    public interface IContactManager
    {
        ContactDataSet Load();
        void Save(ContactDataSet contacts);
    }
}
