using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Isima.InstantMessaging.Contacts;

namespace Isima.InstantMessaging.WcfClient
{
    /// <summary>
    /// Cette classe implémente un gestionnaire de contact basé sur le service WCF.
    /// </summary>
    public class WcfContactsManager : IContactsManager
    {
        public ContactsDataSet Load()
        {
            ContactsDataSet data = new ContactsDataSet();
            using (ContactServiceReference.ContactServiceClient client = new ContactServiceReference.ContactServiceClient())
            {
                ContactServiceReference.Contact[] contacts = client.List();
                if (contacts != null && contacts.Length > 0)
                {
                    foreach (ContactServiceReference.Contact contact in contacts)
                        data.Contacts.AddContactsRow(contact.Address, contact.DisplayName);
                }
            }
            return data;
        }

        public void Save(ContactsDataSet data)
        {
            using (ContactServiceReference.ContactServiceClient client = new ContactServiceReference.ContactServiceClient())
            {
                List<ContactServiceReference.Contact> contacts = new List<ContactServiceReference.Contact>();
                if (data != null && data.Contacts.Count > 0)
                    foreach (ContactsDataSet.ContactsRow row in data.Contacts)
                        contacts.Add(new ContactServiceReference.Contact()
                        {
                            Address = row.Address,
                            DisplayName = row.DisplayName
                        });
                client.Save(contacts.ToArray<ContactServiceReference.Contact>());
            }
        }
    }
}
