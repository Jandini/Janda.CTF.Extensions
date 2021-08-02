using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Janda.CTF
{
    public static class StringExtensions
    {
        public static string ToPlural(this string value, int count)
        {
            if (count > 1 || count == 0)
                return value + "s";

            return value;
        }

        public static string Decrypt(this string value, string key, PaddingMode padding = PaddingMode.None)
        {
            var input = Convert.FromBase64String(value);
            var output = input.Decrypt(key, padding);
            return Encoding.UTF8.GetString(output);
        }

    }
}
