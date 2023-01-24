using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Globalization;
using System.IO;

namespace Logger
{
    internal sealed class FileLogger : BaseLogger
    {

        public override void Log(LogLevel level, string message)
        {
            DateTime localDate = DateTime.Now;
            CultureInfo cultureInfo = new CultureInfo("en-US");

            string logMessage = $"{localDate.ToString(cultureInfo)} {this.ClassName} {level}: {message}";

            using (StreamWriter sw = File.AppendText(this.FilePath))
            {
                sw.WriteLine(logMessage);
                sw.Close();
            }
        }
    }
}
