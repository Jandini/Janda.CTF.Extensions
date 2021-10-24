using System.Linq;

namespace Janda.CTF.Extensions
{
    public static class StringCollectionExtensions
    {

        public static string[] LongestWords(this string[] array)
        {
            return array.OrderByDescending(s => s.Length).ThenBy(s => s).ToArray();
        }

        public static string LongestWord(this string[] array)
        {
            return array.OrderByDescending(s => s.Length).ThenBy(s => s).FirstOrDefault();
        }

    }
}
