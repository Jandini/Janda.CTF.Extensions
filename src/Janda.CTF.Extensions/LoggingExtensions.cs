using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Janda.CTF
{
    public static class LoggingExtensions
    {
        public static T Info<T>(this T o, ILogger logger, string message, params object[] args)
        {
            logger.LogInformation(message, args);
            return o;
        }


        public static T Info<T>(this T o, ILogger logger, string message)
        {
            logger.LogInformation(message + "\n{@o}", o);
            return o;
        }

        public static T Info<T>(this T o, ILogger logger)
        {
            logger.LogInformation("{@o}", o);
            return o;
        }


        public static T Log<T>(this T o, ILogger logger, string message = "", params object[] args)
        {
            var parameters = new List<object>();

            parameters.AddRange(args);
            parameters.Add(o.ToString().Replace("{", "{{").Replace("}", "}}"));

            logger.LogInformation(message + "\n{@o}", parameters.ToArray());
            return o;
        }

    }
}
