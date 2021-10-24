using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Janda.CTF
{
    public static class ByteArrayExtensions
    {

        private static char[] ToHexCharArray(this byte[] bytes)
        {
            int count = bytes.Length;
            char[] hex = new char[count * 2];
            byte b;

            for (int y = 0, x = 0; y < count; ++y, ++x)
            {
                b = ((byte)(bytes[y] >> 4));

                hex[x] = (char)(b > 9
                    ? b + 0x37
                    : b + 0x30);

                b = ((byte)(bytes[y] & 0xF));

                hex[++x] = (char)(b > 9
                    ? b + 0x37
                    : b + 0x30);
            }

            return hex;
        }


        public static string AsString(this char[] array)
        {
            var sb = new StringBuilder();
            foreach (var c in array)
                sb.Append(c);

            return sb.ToString();
        }

        public static string AsString(this IList<char> list)
        {
            var sb = new StringBuilder();
            foreach (var c in list)
                sb.Append(c);

            return sb.ToString();
        }

        private static StringBuilder ToCSharpHexByteArray(this byte[] bytes, string indentation = "\t", int bytesPerLine = 16)
        {
            var result = new StringBuilder(bytes.Length * 8);
            var hex = bytes.ToHexCharArray();

            result.Append(indentation);

            for (int i = 0; i < hex.Length; i += 2)
            {
                result.Append("0x")
                    .Append(hex[i])
                    .Append(hex[i + 1]);

                if (i < hex.Length - 2)
                {
                    result.Append(", ");

                    if ((i / 2 + 1) % bytesPerLine == 0)
                        result.AppendLine().Append(indentation);
                }
            }

            return result;
        }


        public static IEnumerable<int> IndexesOf(this byte[] haystack, byte[] needle, int startIndex = 0, bool includeOverlapping = false)
        {
            int matchIndex = haystack.AsSpan(startIndex).IndexOf(needle);
            while (matchIndex >= 0)
            {
                yield return startIndex + matchIndex;
                startIndex += matchIndex + (includeOverlapping ? 1 : needle.Length);
                matchIndex = haystack.AsSpan(startIndex).IndexOf(needle);
            }
        }


        //public static byte[] LogHexDump(this byte[] bytes, ILogger logger, string message = "", string indentation = "", string asciiSeparator = "   ", int bytesPerLine = 16, bool cleanAscii = true, char nonPrintableChar = '.', int showStrings = 8, bool stringsOnly = false)
        //    => LogAsHexDump(bytes, logger, LogLevel.Information, message, indentation, asciiSeparator, bytesPerLine, cleanAscii, nonPrintableChar, showStrings, stringsOnly);

        public static byte[] LogAsHexDump(this byte[] bytes, ILogger logger, LogLevel logLevel = LogLevel.Information, string message = "", string indentation = "", string asciiSeparator = "   ", int bytesPerLine = 16, bool cleanAscii = true, char nonPrintableChar = '.', int showStrings = 8, bool stringsOnly = false)
        {
            logger?.Log(logLevel, $"{message}{(string.IsNullOrEmpty(message) ? string.Empty : " ")}{{bytes}} {bytes.Length.ToPluralWord("byte")} {{dump}}", bytes.Length, bytes.ToHexDump(string.Empty, indentation, asciiSeparator, bytesPerLine, cleanAscii, nonPrintableChar, showStrings, stringsOnly));
            return bytes;
        }
    
              


        /// <summary>
        /// Convert byte array to hex dump on the left and ascii characters on the right
        /// </summary>
        /// <param name="bytes">The byte array</param>
        /// <param name="indentation">Left indentation</param>
        /// <param name="asciiSeparator">Space between hex bytes and ascii characters</param>
        /// <param name="bytesPerLine">Number of bytes per line</param>
        /// <returns>Hex dump string</returns>
        public static string ToHexDump(this byte[] bytes, string message = "", string indentation = "", string asciiSeparator = "   ", int bytesPerLine = 16, bool cleanAscii = true, char nonPrintableChar = '.', int showStrings = 8, bool stringsOnly = false)
        {
            if (bytes == null)
                return string.Empty;

            var result = new StringBuilder(bytes.Length * 8);

            var hex = bytes.ToHexCharArray();

            result.Append(message);
            result.AppendLine().Append(indentation);

            var words = new List<string>();
            var ascii = new StringBuilder();
            var text = new StringBuilder();

            int lineStart = result.Length;

            for (int i = 0, j = 0; i < hex.Length; i += 2, j++)
            {
                result.Append(hex[i]).Append(hex[i + 1]);

                char c = (char)bytes[j];

                if (!cleanAscii)
                    ascii.Append(!char.IsControl(c) ? c : nonPrintableChar);
                else
                    ascii.Append(bytes[j] <= 0x7F && bytes[j] > 0x20 ? c : nonPrintableChar);

                if (bytes[j] <= 0x7F && bytes[j] > 0x20)
                {
                    text.Append(c);
                }
                else
                {
                    if (showStrings > 0 && text.Length >= showStrings)
                        words.Add(text.ToString());

                    text = new StringBuilder();
                }

                if (i < hex.Length - 2)
                {
                    result.Append(' ');

                    if ((i / 2 + 1) % bytesPerLine == 0)
                    {
                        if (stringsOnly && words.Count == 0)
                            result.Remove(lineStart, result.Length - lineStart);
                        else
                        {
                            result.Append(asciiSeparator).Append(ascii).Append(asciiSeparator).Append(string.Join(' ', words));
                            result.AppendLine().Append(indentation);
                        }
                        
                        ascii = new StringBuilder();
                        words = new List<string>();

                        lineStart = result.Length;
                    }
                }
            }

            if (ascii.Length > 0)
            {
                result.Append(new string(' ', (bytesPerLine - ascii.Length) * 3 + 1));
                result.Append(asciiSeparator).Append(ascii);

                if (showStrings > 0 && text.Length >= showStrings)
                    result
                         .Append(new string(' ', bytesPerLine - ascii.Length))
                         .Append(asciiSeparator).Append(text);
            }

            return result.ToString();
        }
    }
}
