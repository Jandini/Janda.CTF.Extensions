using System;
using System.Collections.Generic;
using System.Text;

namespace Janda.CTF
{
    public static class StringPatternExtensions
    {       
        public static T[] ParseAsIntegerPattern<T>(this string value, Func<string, T> parse, string separator = " ")
        {
            var entries = value.Split(separator);
            var values = new List<T>();

            foreach (var entry in entries)
            {
                var trimmed = entry.Trim();

                if (!string.IsNullOrEmpty(trimmed))
                {
                    var parsed = parse(trimmed);

                    if (parse != null)
                        values.Add(parsed);
                }
            }

            return values.ToArray();
        }


        public static byte[] ParseAsSignedBytePattern(this string value, string separator = " ")            
        {
            return value.ParseAsIntegerPattern<byte>((s) =>  (byte)sbyte.Parse(s), separator);
        }

        public static byte[] ParseAsBytePattern(this string value, string separator = " ")
        {
            return value.ParseAsIntegerPattern<byte>((s) => byte.Parse(s), separator);
        }

        public static byte[] ParseAsHexPattern(this string value, string separator = " ", bool paddingRequired = true)
        {
            var entries = value.Split(separator);
            var builder = new StringBuilder();

            foreach (var entry in entries)
            {
                var trimmed = entry.Trim();

                if (paddingRequired && (trimmed.Length % 2) != 0)
                    trimmed = trimmed.PadLeft(trimmed.Length + 1, '0');

                builder.Append(trimmed);
            }

            return builder.ToString().ParseAsHexString();
        }


        private static byte[] ParseAsHexString(this string value)
        {
            int length = value.Length;
            byte[] result = new byte[length / 2];
            byte char1, char2;

            length = length / 2 * 2;

            for (int y = 0, x = 0; x < length; ++y, x++)
            {
                char1 = (byte)value[x];

                if (char1 > 0x60)
                    char1 -= 0x57;
                else
                    if (char1 > 0x40)
                    char1 -= 0x37;
                else
                    char1 -= 0x30;

                char2 = (byte)value[++x];

                if (char2 > 0x60)
                    char2 -= 0x57;
                else
                    if (char2 > 0x40)
                    char2 -= 0x37;
                else
                    char2 -= 0x30;

                result[y] = (byte)((char1 << 4) + char2);
            }

            return result;
        }
    }
}
