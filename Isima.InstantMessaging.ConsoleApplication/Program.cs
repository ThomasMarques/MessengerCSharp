using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isima.InstantMessaging.ConsoleApplication
{
    class Program
    {
        /// <summary>
        /// Permet d'analyser les arguments d'envoi du message.
        /// </summary>
        /// <param name="from">Expéditeur du message.</param>
        /// <param name="to">Destinataire du message.</param>
        public void AnalyseArgument(String from, String to)
        {
            
        }


        /// <summary>
        /// Permet de tchatter avec un destinataire. Pour finir la convertion on tapera le mot BYE.
        /// </summary>
        public void RunConsole()
        {
            String saisie;

            do
            {
                saisie = Console.ReadLine();
            }
            while (saisie.Equals("BYE"));
        }



        public static void Main(int argc, String[] argv)
        {
            Program program = new Program();



        }

    }
}
