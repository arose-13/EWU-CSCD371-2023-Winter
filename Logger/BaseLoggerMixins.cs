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
                logger.Log(LogLevel.Error, message);
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
                logger.Log(LogLevel.Warning, message);
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
                logger.Log(LogLevel.Information, message);
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
                logger.Log(LogLevel.Debug, message);
            }
        }
    }
}
