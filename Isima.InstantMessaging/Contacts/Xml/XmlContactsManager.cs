using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isima.InstantMessaging.Contacts.Xml
{
    public class XmlContactsManager : IContactsManager
    {
        private string fileName;

        public XmlContactsManager(string fileName)
        {
            this.fileName = fileName;
        }

        public string FileName
        {
            get { return fileName; }
            private set { fileName = value; }
        }

        public ContactsDataSet Load()
        {
            ContactsDataSet contacts = new ContactsDataSet();

            if (System.IO.File.Exists(fileName))
                contacts.ReadXml(fileName);

            return contacts;
        }

        public void Save(ContactsDataSet contacts)
        {
            contacts.WriteXml(this.FileName);
        }
    }
}
