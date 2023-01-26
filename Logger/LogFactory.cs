using System.Runtime.Serialization;
using System;
[assembly: CLSCompliant(true)]
namespace Logger
{
    public class LogFactory
    {

        private string? _FilePath;
        public string FilePath { get => _FilePath!; set => _FilePath = value; }
        public BaseLogger? CreateLogger(string className, string filePath)
        {
            if (className == "FileLogger")
            {
                FileLogger logger = new FileLogger(filePath);
                ConfigureFileLogger(logger, filePath);
                logger.ClassName = className;

                if (string.IsNullOrEmpty(logger.FilePath))
                {
                    return null;
                }
                return logger;
            }
            else
            {
                BaseLogger logger = new FileLogger(filePath);
                logger.ClassName = className;
            }

            return null;
        }

        public void ConfigureFileLogger(FileLogger logger, string filePath)
        {
            if (!string.IsNullOrEmpty(filePath) && logger is not null)
            {
                FilePath = filePath;
                logger.FilePath = filePath;
            }
        }
    }
}
