using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Isima.InstantMessaging.Text
{
    public class Sanitizer
    {
        static public string Sanitize(string input)
        {
            const string pattern = @"[^\w\d\p{Z}\p{P}]";
            return Regex.Replace(input, pattern, string.Empty);
        }

        static public string NeutralizeUrl(string input)
        {
            const string pattern = @"\b(?<Protocol>(http|ftp|https|file):\/\/)";
            return Regex.Replace(input, pattern, "_${Protocol}");
        }

        static public string SanitizeFileName(string input)
        {
            const string pattern = @"[^\w\d]";
            return Regex.Replace(input, pattern, string.Empty);
        }
    }
}
