using Microsoft.Extensions.Logging;
using System;

namespace Janda.CTF
{
    public static class LoopExtensions
    {
        public static int Times(this int value, Action<int> callback)
        {

            try
            {
                for (int i = 0; i < value; i++)
                    callback(i);
            }
            catch (BreakTimesException)
            {

            }

            return value;
        }


        public static int Times(this int value, int from, Action<int> callback)
        {
            try
            {
                for (int i = from, c = from + value; i < c; i++)
                    callback(i);
            }
            catch (BreakTimesException)
            {

            }

            return value;
        }


        public static int Times(this int value, Action callback)
        {
            try
            {
                for (int i = 0; i < value; i++)
                    callback();
            }
            catch (BreakTimesException)
            {

            }

            return value;
        }


        public static int Times(this int value, ILogger logger, Action callback)
        {
            try
            {
                for (int i = 0; i < value; i++)
                {
                    logger.LogTrace($"{{time}}{(i + 1).ToOrdinalSuffix()} time", i + 1);
                    callback();
                }
            }
            catch (BreakTimesException)
            {

            }

            return value;
        }


        public static void Break(this int value)
        {
            throw new BreakTimesException();            
        }


    }
}
