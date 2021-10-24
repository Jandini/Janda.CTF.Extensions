namespace Janda.CTF
{
    public static class OrdinalExtensions
    {

        public static string ToPluralString(this int value, string word)
        {
            string result = $"{value} {word}";

            if (value > 1 || value == 0)
                return result + "s";

            return result;
        }

        public static string ToPluralWord(this int value, string word)
        {
            string result = $"{word}";

            if (value > 1 || value == 0)
                return result + "s";

            return result;
        }

        public static string ToOrdinalString(this int value)
        {
            if (value <= 0)
                return value.ToString();

            switch (value % 100)
            {
                case 11:
                case 12:
                case 13:
                    return value + "th";

                default:
                    return (value % 10) switch
                    {
                        1 => value + "st",
                        2 => value + "nd",
                        3 => value + "rd",
                        _ => value + "th",
                    };
            }
        }

        public static string ToOrdinalSuffix(this int value)
        {
            if (value <= 0)
                return string.Empty;

            switch (value % 100)
            {
                case 11:
                case 12:
                case 13:
                    return "th";

                default:
                    return (value % 10) switch
                    {
                        1 => "st",
                        2 => "nd",
                        3 => "rd",
                        _ => "th",
                    };
            }
        }
    }
}
