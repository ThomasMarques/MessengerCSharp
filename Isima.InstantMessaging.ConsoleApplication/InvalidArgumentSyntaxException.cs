using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isima.InstantMessaging.ConsoleApplication
{
    [Serializable]
    public class InvalidArgumentSyntaxException : Exception
    {
        private const string KeyArgument = "Argument";

        public InvalidArgumentSyntaxException(string argument)
        {
            this.Data.Add(KeyArgument, argument);
        }

        public InvalidArgumentSyntaxException(string argument, string message)
            : base(message)
        {
            this.Data.Add(KeyArgument, argument);
        }

        public InvalidArgumentSyntaxException(string argument, string message, Exception inner)
            : base(message, inner)
        {
            this.Data.Add(KeyArgument, argument);
        }

        protected InvalidArgumentSyntaxException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }

        public override string Message
        {
            get
            {
                string argument = this.Data[KeyArgument] as string;
                if (argument != null)
                    return string.Concat("Invalid argument syntax: ", argument);
                else
                    return "Invalid argument syntax.";
            }
        }
    }
}
