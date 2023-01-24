using System;
using System.Globalization;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(BaseLogger logger, string message, string[] messageArgs)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            else
            {
                CultureInfo culture = new CultureInfo("en-US");
                logger.Log(LogLevel.Error, string.Format(culture, message, messageArgs));
            }

        }

        public static void Warning(BaseLogger logger, string message, string[] messageArgs)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            else
            {
                CultureInfo culture = new CultureInfo("en-US");
                logger.Log(LogLevel.Warning, string.Format(culture, message, messageArgs));
            }
        }

        public static void Information(BaseLogger logger, string message, string[] messageArgs)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            else
            {
                CultureInfo culture = new CultureInfo("en-US");
                logger.Log(LogLevel.Information, string.Format(culture, message, messageArgs));
            }
        }

        public static void Debug(BaseLogger logger, string message, string[] messageArgs)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            else
            {
                CultureInfo culture = new CultureInfo("en-US");
                logger.Log(LogLevel.Debug, string.Format(culture, message, messageArgs));
            }
        }
    }
}
