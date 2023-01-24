using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {

        [TestMethod]
        public void Create_GivenFile_ReturnsFileLogger()
        {
            // Assemble
            LogFactory factory = new LogFactory();

            // Act
            BaseLogger logger = factory.CreateLogger("FileLogger", @"./file.txt");

            // Assert
            Assert.IsInstanceOfType(logger, typeof(BaseLogger));
        }

        [TestMethod]
        public void Configure_GivenFile_ChangesLoggerFile()
        {
            // Assemble
            LogFactory factory = new LogFactory();
            FileLogger logger = (FileLogger)factory.CreateLogger("FileLogger", @"./file.txt");

            // Act
            factory.ConfigureFileLogger(logger, @"./file2.txt");

            // Assert
            Assert.IsFalse(logger.FilePath == @"./file.txt");
        }

    }
}
