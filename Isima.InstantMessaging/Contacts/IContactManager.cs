using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isima.InstantMessaging.Contacts
{
    public interface IContactManager
    {
        /// <summary>
        /// Fonction permettant de charger le ContactDataSet.
        /// </summary>
        /// <returns>Le ContactDataSet construit</returns>
        ContactDataSet Load();

        /// <summary>
        /// Fonction permettant la sauvegarde du ContactDataSet.
        /// </summary>
        /// <param name="contacts">Le ContactDataSet à sauvegarder</param>
        void Save(ContactDataSet contacts);
    }
}
