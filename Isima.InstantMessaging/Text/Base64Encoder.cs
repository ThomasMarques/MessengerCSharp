using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isima.InstantMessaging.Text
{
    public class Base64Encoder
    {
        static public string Encode(string input)
        {
            return System.Convert.ToBase64String(System.Text.UTF8Encoding.UTF8.GetBytes(input));
        }

        static public string Decode(string input)
        {
            return System.Text.UTF8Encoding.UTF8.GetString(System.Convert.FromBase64String(input));
        }
    }
}
