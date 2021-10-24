using System;
using System.Collections.Generic;

namespace Janda.CTF
{
    public static class ListExtensions
    {
        public static T Nth<T>(this List<T> list, int nth)
        {          
            try
            {
                return list[nth - 1];
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException($"The {(nth < 0 ? $"negative ({nth})" : nth.ToOrdinalString())} element was not found in the {typeof(T).Name.ToLower()} list with {list.Count.ToPluralString("element")}.", ex);
            }
        }

        public static T First<T>(this List<T> list)
        {
            return list.Nth(1);
        }

        public static T Second<T>(this List<T> list)
        {
            return list.Nth(2);
        }

        public static T Third<T>(this List<T> list)
        {
            return list.Nth(3);
        }

        public static T Fourth<T>(this List<T> list)
        {
            return list.Nth(4);
        }

        public static T Fifth<T>(this List<T> list)
        {
            return list.Nth(5);
        }

        public static T Sixth<T>(this List<T> list)
        {
            return list.Nth(6);
        }

        public static T Seventh<T>(this List<T> list)
        {
            return list.Nth(7);
        }

        public static T Eighth<T>(this List<T> list)
        {
            return list.Nth(8);
        }

        public static T Ninth<T>(this List<T> list)
        {
            return list.Nth(9);
        }

        public static T Tenth<T>(this List<T> list)
        {
            return list.Nth(10);
        }

        public static T Eleventh<T>(this List<T> list)
        {
            return list.Nth(11);
        }

        public static T Twelfth<T>(this List<T> list)
        {
            return list.Nth(12);
        }

        public static T Thirteenth<T>(this List<T> list)
        {
            return list.Nth(13);
        }

        public static T Fourteenth<T>(this List<T> list)
        {
            return list.Nth(14);
        }

        public static T Fifteenth<T>(this List<T> list)
        {
            return list.Nth(15);
        }

        public static T Sixteenth<T>(this List<T> list)
        {
            return list.Nth(16);
        }

        public static T Seventeenth<T>(this List<T> list)
        {
            return list.Nth(17);
        }

        public static T Eighteenth<T>(this List<T> list)
        {
            return list.Nth(18);
        }

        public static T Nineteenth<T>(this List<T> list)
        {
            return list.Nth(19);
        }

        public static T Twentieth<T>(this List<T> list)
        {
            return list.Nth(20);
        }

        public static T Last<T>(this List<T> list) 
        {
            return list.Nth(list.Count);
        }

        public static T FromTheEnd<T>(this List<T> list, int nth)
        {
            return list.Nth(list.Count - nth);
        }
    }
}
