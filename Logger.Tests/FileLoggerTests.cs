using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void Write_GivenFile_LogMessage()
        {
            // Assemble
            LogFactory factory = new LogFactory();
            BaseLogger logger = factory.CreateLogger("FileLogger", @"./file.txt");
            Console.WriteLine(logger.FilePath);

            // Act
            LogLevel logLevel = LogLevel.Warning;
            logger.Log(logLevel, "Error Message");
            DateTime localDate = DateTime.Now;
            CultureInfo cultureInfo = new CultureInfo("en-US");

            string fileText = System.IO.File.ReadAllText(@"./file.txt");

            // Assert
            Assert.AreEqual($"{localDate.ToString(cultureInfo)} {logger.ClassName} {logLevel}: Error Message" + "\n", fileText);
        }
    }
}
