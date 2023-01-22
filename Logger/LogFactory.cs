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
                // FileLogger logger = new FileLogger();
                ConfigureFileLogger(logger, filePath);
                ConfigureClassNameLogger(logger, className);
                // return logger;
            }

            return logger;
        }

        public void ConfigureFileLogger(BaseLogger logger, string filePath)
        {
            if (!string.IsNullOrEmpty(filePath) && logger is not null)
            {
                logger.FilePath = filePath;
            }
        }

        public void ConfigureClassNameLogger(BaseLogger logger, string className)
        {
            if (!string.IsNullOrEmpty(className) && logger is not null)
            {
                logger.ClassName = className;
            }
        }
    }
}
