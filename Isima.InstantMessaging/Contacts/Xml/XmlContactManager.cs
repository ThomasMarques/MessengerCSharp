using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace Isima.InstantMessaging.Contacts.Xml
{
    public class XmlContactManager : IContactManager
    {
        /// <summary>
        /// Fonction permettant de charger le fichier Xml.
        /// </summary>
        /// <returns>Le ContactDataSet construit par le fichier Xml</returns>
        public ContactDataSet Load()
        {
            ContactDataSet contacts = null;

            try
            {
                FileStream txt = new FileStream("contacts.xml", FileMode.Open);

                XmlSerializer xml = new XmlSerializer(typeof(ContactDataSet));

                contacts = (ContactDataSet)xml.Deserialize(txt);
            }
            catch (Exception e)
            {

            }
            
            return contacts;
        }

        /// <summary>
        /// Fonction permettant la sauvegarde du ContactDataSet au format Xml.
        /// </summary>
        /// <param name="contacts">Le ContactDataSet à sauvegarder</param>
        public void Save(ContactDataSet contacts)
        {
            XmlSerializer xml = new XmlSerializer(typeof(ContactDataSet));
            TextWriter txt = new StreamWriter("contacts.xml");

            xml.Serialize(txt, contacts);
        }
    }
}
