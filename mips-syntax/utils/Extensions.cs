using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace mips_syntax.utils
{
    public static class Extensions
    {
        public static bool IsLabel(this string source)
        {
            return source.IsMIPSLabel();
        }
        
        public static bool CanReadFrom(this string source,bool end=false)
        {
            return source.CanWriteTo(end) || source.IsSpecialRegister(end);
        }

        public static bool CanWriteTo(this string source,bool end = false)
        {
            return
                source.IsTemporaryRegister(end)
                 || source.IsStoreRegister(end)
                 || source.IsMemoryLocation(end);
        }

        public static List<string> ParseInstruction(this string source)
        {
            char[] delimiterChars = { ' '};
            var result = source.Split(delimiterChars,StringSplitOptions.RemoveEmptyEntries).ToList();
            return result;
        }

        public static Boolean IsTemporaryRegister(this string source,bool end= false)
        {
            if (end)
                return Regex.IsMatch(source, @"^\$t[0-9]$");
            return Regex.IsMatch(source, @"^\$t[0-9],$");
        }

        public static Boolean IsStoreRegister(this string source, bool end = false)
        {
            if (end) 
                return Regex.IsMatch(source, @"^\$s[0-9]$");
            return Regex.IsMatch(source, @"^\$s[0-9],$");
        }

        public static Boolean IsReserveredRegister(this string source, bool end = false)
        {
            return (Regex.IsMatch(source, @"^\$k[0-1]$"));
        }
        public static Boolean IsMIPSConstant(this string source, bool end = false)
        {
            return (Regex.IsMatch(source, @"[-+]?\b\d+\b"));
        }

        public static Boolean IsSpecialRegister(this string source, bool end = false)
        {
            if(end)
                return (Regex.IsMatch(source, @"^\$zero"));
            return (Regex.IsMatch(source, @"^\$zero$,"));
        }
        public static Boolean IsMIPSLabel(this string source, bool end = false)
        {
            return (Regex.IsMatch(source, @"^[a-zA-Z0-9]+\b\:$"));
        }
        public static Boolean IsMemoryLocation(this string source, bool end = false)
        {
            if(end)
                return (Regex.IsMatch(source, @"^\d+\(\$[st][0-9]\)$"));
            return (Regex.IsMatch(source, @"^\d+\(\$[st][0-9]\),$"));
        }
    }
}