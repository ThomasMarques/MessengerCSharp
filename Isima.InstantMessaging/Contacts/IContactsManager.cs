using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isima.InstantMessaging.Contacts
{
    public interface IContactsManager
    {
        ContactsDataSet Load();
        void Save(ContactsDataSet contacts);
    }
}
