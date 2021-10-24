using System;

namespace Janda.CTF
{

    internal class BreakTimesException : Exception
    {
        public BreakTimesException()
        {
        }

        public BreakTimesException(string message) : base(message)
        {
        }
    }
}