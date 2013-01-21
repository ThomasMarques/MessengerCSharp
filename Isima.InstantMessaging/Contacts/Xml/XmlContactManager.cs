﻿using System;
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


        public void Save(ContactDataSet contacts)
        {
            XmlSerializer xml = new XmlSerializer(typeof(ContactDataSet));
            TextWriter txt = new StreamWriter("contacts.xml");

            xml.Serialize(txt, contacts);
        }
    }
}