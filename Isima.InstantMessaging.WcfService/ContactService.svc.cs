using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Isima.InstantMessaging.Contacts;
using Isima.InstantMessaging.Contacts.Xml;

namespace Isima.InstantMessaging.WcfService
{
    public class ContactService : IContactService
    {
        private IContactsManager CurrentContactsManager
        {
            get
            {
                string fileName = "public_contacts.xml";

                if (!OperationContext.Current.ServiceSecurityContext.IsAnonymous)
                    fileName = string.Concat(Text.Sanitizer.SanitizeFileName(OperationContext.Current.ServiceSecurityContext.WindowsIdentity.Name), "_contacts.xml");

                string filePath = System.IO.Path.Combine(System.IO.Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, "App_Data"), fileName);
                return new XmlContactsManager(filePath);
            }
        }

        public IList<Contact> List()
        {
            ContactsDataSet data = CurrentContactsManager.Load();

            List<Contact> contacts = new List<Contact>();
            for (int i = 0; i < data.Contacts.Count; i++)
            {
                ContactsDataSet.ContactsRow row = data.Contacts[i];
                contacts.Add(new Contact { Address = row.Address, DisplayName = row.DisplayName });
            }
            return contacts;
        }

        public void Save(IList<Contact> contacts)
        {
            ContactsDataSet data = new ContactsDataSet();
            foreach (Contact contact in contacts)
            {
                data.Contacts.AddContactsRow(contact.Address, contact.DisplayName);
            }

            IContactsManager contactsManager = CurrentContactsManager;
            contactsManager.Save(data);
        }
    }
}
