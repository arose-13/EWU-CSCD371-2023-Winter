using System.Runtime.Serialization;

namespace Logger
{
    public class LogFactory
    {
        public BaseLogger CreateLogger(string className, string filePath)
        {
            if (className == "FileLogger")
            {
                FileLogger logger = new FileLogger();
                ConfigureFileLogger(logger, filePath);
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
