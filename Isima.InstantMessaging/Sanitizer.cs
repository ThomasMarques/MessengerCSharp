using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Isima.InstantMessaging
{
    class Sanitizer
    {

        /// <summary>
        /// Fonction permettant de neutraliser les url dans un texte.
        /// </summary>
        /// <param name="txt">Texte à neutraliser.</param>
        /// <returns>Retourne le texte avec un underscore devant l'url.</returns>
        public String NeutralizeUrl(String txt)
        {
            String pattern = @"\b((http|https|ftp|file):\/\/";

            return Regex.Replace(txt,pattern,"_{1}");
        }


        /// <summary>
        /// Permet de nettoyer un texte.
        /// </summary>
        /// <param name="txt">texte à clean.</param>
        /// <returns>Le texte nettoyé.</returns>
        public String Sanitize(String txt)
        {
            String pattern = @"[^\w\d]";

            return Regex.Replace(txt,pattern,String.Empty);
        }

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        public Sanitizer()
        {
        }

    }
}
