using System.Runtime.Serialization;
using System;
// [assembly: CLSCompliant(true)]
namespace Logger
{
    public class LogFactory
    {
        public BaseLogger CreateLogger(string className, string filePath)
        {
            BaseLogger logger = new FileLogger();
            logger.ClassName = className;
            if (className == "FileLogger")
            {
                ConfigureFileLogger(logger, filePath);
                logger.ClassName = className;
                return logger;
            }

            return null;
        }

        public void ConfigureFileLogger(BaseLogger logger, string filePath)
        {
            if (!string.IsNullOrEmpty(filePath) && logger is not null)
            {
                logger.FilePath = filePath;
            }
        }
    }
}
