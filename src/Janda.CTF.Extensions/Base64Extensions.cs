using System;
using System.Text;

namespace Janda.CTF.Extensions
{
    public static class Base64Extensions
    {

        public static class Base64Url
        {
            public static string Encode(string text)
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(text)).TrimEnd('=').Replace('+', '-')
                    .Replace('/', '_');
            }

            public static string Decode(string text)
            {
                text = text.Replace('_', '/').Replace('-', '+');
                switch (text.Length % 4)
                {
                    case 2:
                        text += "==";
                        break;
                    case 3:
                        text += "=";
                        break;
                }
                return Encoding.UTF8.GetString(Convert.FromBase64String(text));
            }
        }


        public static int DecodeBase64Digit(char digit, string digit62 = "+-.~", string digit63 = "/_,")
        {
            if (digit >= 'A' && digit <= 'Z') return digit - 'A';
            if (digit >= 'a' && digit <= 'z') return digit + (26 - 'a');
            if (digit >= '0' && digit <= '9') return digit + (52 - '0');
            if (digit62.IndexOf(digit) > -1) return 62;
            if (digit63.IndexOf(digit) > -1) return 63;
            return -1;
        }

        public static char EncodeBase64Digit(int digit, char digit62 = '+', char digit63 = '/')
        {
            digit &= 63;
            if (digit < 52)
                return (char)(digit < 26 ? digit + 'A' : digit + ('a' - 26));
            else if (digit < 62)
                return (char)(digit + ('0' - 52));
            else
                return digit == 62 ? digit62 : digit63;
        }




    }
}
