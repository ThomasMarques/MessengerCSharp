using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Isima.InstantMessaging.Text;

namespace Isima.InstantMessaging.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            const string Usage = "\nUsage: Isima.InstantMessaging.ConsoleApplication from:<sender address> to:<receiver address>";

            if (args.Length < 2)
            {
                Console.Error.WriteLine(Usage);
            }
            else
            {
                try
                {
                    foreach (string arg in args)
                        AnalyzeArgument(arg);

                    RunConsole();
                }
                catch (UnknownArgumentException uns)
                {
                    Console.Error.WriteLine();
                    Console.Error.WriteLine(uns.Message);
                    Console.Error.WriteLine(Usage);
                }
                catch (InvalidArgumentSyntaxException unk)
                {
                    Console.Error.WriteLine();
                    Console.Error.WriteLine(unk.Message);
                    Console.Error.WriteLine(Usage);
                }
            }
        }

        private static void RunConsole()
        {
            while (1 == 1)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (string.Compare(input, "BYE", false) == 0)
                {
                    break;
                }
                else
                {
                    string sanitizedText = Sanitizer.Sanitize(Sanitizer.NeutralizeUrl(input));
                    Console.WriteLine("Sanitized text: {0}.", sanitizedText);

                    string encodedText = Base64Encoder.Encode(sanitizedText);
                    Console.WriteLine("Encoded text: {0}.", encodedText);

                    string decodedText = Base64Encoder.Decode(encodedText);
                    Console.WriteLine("Decoded text: {0}", decodedText);
                }
            }
        }

        private static void AnalyzeArgument(string argument)
        {
            string[] elements = argument.Split(':', '=');
            if (elements.Length != 2)
                throw new InvalidArgumentSyntaxException(argument);

            try
            {
                ValidArguments arg = (ValidArguments)Enum.Parse(typeof(ValidArguments), elements[0], true);
                Console.WriteLine("{0} is {1}", arg, elements[1]);
            }
            catch (ArgumentException)
            {
                throw new UnknownArgumentException(elements[0]);
            }
        }
    }
}
