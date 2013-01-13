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
        public void AnalyseArgument(String[] args)
        {
            if(args.Length != 3)
                throw new ArgumentException();

            if (!args[2].Contains("to:") || !args[1].Contains("from:"))
                throw new ArgumentException();

            String emetteur = args[1].Substring(5);
            String dest = args[2].Substring(3);
            Console.WriteLine("From is " + emetteur );
            Console.WriteLine("To is " +  dest);
            Console.WriteLine();
        }


        /// <summary>
        /// Permet de tchatter avec un destinataire. Pour finir la convertion on tapera le mot BYE.
        /// </summary>
        public void RunConsole()
        {
            String saisie;
            Console.WriteLine("Conversation en cours :");
            Sanitizer sanitizer = new Sanitizer();
            Base64Encoder base64 = new Base64Encoder();

            do
            {
                Console.Write("> ");
                saisie = Console.ReadLine();
                saisie = sanitizer.Sanitize(saisie);
                Console.WriteLine("Sanitized text : " + saisie);
                saisie = base64.Encode(saisie);
                Console.WriteLine("Encoded text : " + saisie);
                saisie = base64.Decode(saisie);
                Console.WriteLine("Decoded text : " + saisie);

            }
            while (!saisie.Equals("BYE"));
            Console.WriteLine("Fin de la conversation.");
        }



        public static void Main(String[] args)
        {
            Program program = new Program();

            try
            {
                program.AnalyseArgument(args);
                program.RunConsole();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Usage : Isima.InstantMessaging.Console from:<sender address> to:<receiver address> ");
            }
        }

    }
}
