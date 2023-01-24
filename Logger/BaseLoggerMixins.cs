using System;

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
                logger.Log(LogLevel.Error, string.Format(message, messageArgs));
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
                logger.Log(LogLevel.Warning, string.Format(message, messageArgs));
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
                logger.Log(LogLevel.Information, string.Format(message, messageArgs));
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
                logger.Log(LogLevel.Debug, string.Format(message, messageArgs));
            }
        }
    }
}
