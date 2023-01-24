using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Globalization;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {

        private string? _FilePath;
        public string FilePath { get => _FilePath!; set => _FilePath = value; }

        public FileLogger(string filePath)
        {
            FilePath = filePath;
        }
        public override void Log(LogLevel level, string message)
        {
            DateTime localDate = DateTime.Now;
            CultureInfo cultureInfo = new CultureInfo("en-US");

            string logMessage = $"{localDate.ToString(cultureInfo)} {this.ClassName} {level}: {message}";

            using (StreamWriter sw = File.AppendText(FilePath))
            {
                sw.WriteLine(logMessage);
                sw.Close();
            }
        }
    }
}
