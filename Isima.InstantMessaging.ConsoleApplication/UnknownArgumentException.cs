using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isima.InstantMessaging.ConsoleApplication
{
    [Serializable]
    public class UnknownArgumentException : Exception
    {
        private const string KeyArgument = "Argument";

        public UnknownArgumentException(string argument) 
        {
            this.Data.Add(KeyArgument, argument);
        }
        
        public UnknownArgumentException(string argument, string message) 
            : base(message) 
        {
            this.Data.Add(KeyArgument, argument);
        }
        
        public UnknownArgumentException(string argument, string message, Exception inner) 
            : base(message, inner) 
        {
            this.Data.Add(KeyArgument, argument);
        }

        protected UnknownArgumentException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context) 
        { 
        }

        public override string Message
        {
            get
            {
                string argument = this.Data[KeyArgument] as string;
                if (argument != null)
                    return string.Concat("Unknown argument: ", argument);
                else
                    return "Unknown argument.";
            }
        }
    }
}
