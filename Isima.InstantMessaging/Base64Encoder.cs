using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isima.InstantMessaging
{
    public class Base64Encoder
    {

        /// <summary>
        /// Permets d'encoder un texte passé en paramètre.
        /// </summary>
        /// <param name="txt">Texte à encoder.</param>
        /// <returns>retourne le texte codé en base 64.</returns>
        public String Encode(String txt)
        {
            if(txt == null)
                throw new ArgumentNullException();

            System.Text.UTF8Encoding encoding=new System.Text.UTF8Encoding();
            return System.Convert.ToBase64String(encoding.GetBytes(txt));
        }

        /// <summary>
        /// Permets d'encoder un texte passé en paramètre.
        /// </summary>
        /// <param name="code">Texte encoder en base 64.</param>
        /// <returns>retourne le texte décodé.</returns>
        public String Decode(String code)
        {
            if (code == null)
                throw new ArgumentNullException();

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return System.Text.ASCIIEncoding.ASCII.GetString(System.Convert.FromBase64String(code));
        }

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        public Base64Encoder()
        {
        }

    }
}
