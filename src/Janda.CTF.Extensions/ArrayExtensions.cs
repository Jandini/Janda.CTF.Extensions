using System;

namespace Janda.CTF
{
    public static class ArrayExtensions
    {
        public static T Nth<T>(this T[] array, int nth)
        {
            try
            {
                return array[nth - 1];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException($"The {nth.ToOrdinalString()} element was not found in the {typeof(T).Name.ToLower()} array with {array.Length.ToPluralString("element")}.", ex);
            }
        }

        public static T First<T>(this T[] array)
        {
            return array.Nth(1);
        }

        public static T Second<T>(this T[] array)
        {
            return array.Nth(2);
        }

        public static T Third<T>(this T[] array)
        {
            return array.Nth(3);
        }

        public static T Fourth<T>(this T[] array)
        {
            return array.Nth(4);
        }

        public static T Fifth<T>(this T[] array)
        {
            return array.Nth(5);
        }

        public static T Sixth<T>(this T[] array)
        {
            return array.Nth(6);
        }

        public static T Seventh<T>(this T[] array)
        {
            return array.Nth(7);
        }

        public static T Eighth<T>(this T[] array)
        {
            return array.Nth(8);
        }

        public static T Ninth<T>(this T[] array)
        {
            return array.Nth(9);
        }

        public static T Tenth<T>(this T[] array)
        {
            return array.Nth(10);
        }

        public static T Eleventh<T>(this T[] array)
        {
            return array.Nth(11);
        }

        public static T Twelfth<T>(this T[] array)
        {
            return array.Nth(12);
        }

        public static T Thirteenth<T>(this T[] array)
        {
            return array.Nth(13);
        }

        public static T Fourteenth<T>(this T[] array)
        {
            return array.Nth(14);
        }

        public static T Fifteenth<T>(this T[] array)
        {
            return array.Nth(15);
        }

        public static T Sixteenth<T>(this T[] array)
        {
            return array.Nth(16);
        }

        public static T Seventeenth<T>(this T[] array)
        {
            return array.Nth(17);
        }

        public static T Eighteenth<T>(this T[] array)
        {
            return array.Nth(18);
        }

        public static T Nineteenth<T>(this T[] array)
        {
            return array.Nth(19);
        }

        public static T Twentieth<T>(this T[] array)
        {
            return array.Nth(20);
        }

        public static T Last<T>(this T[] array)
        {
            return array.Nth(array.Length);
        }

        public static T FromTheEnd<T>(this T[] array, int nth)
        {
            return array.Nth(array.Length - nth);
        }
    }
}
