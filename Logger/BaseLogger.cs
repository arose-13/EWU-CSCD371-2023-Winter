namespace Logger
{
    public abstract class BaseLogger
    {
        private string? _FilePath;
        public string FilePath { get => _FilePath!; set => _FilePath = value; }

        public abstract void Log(LogLevel logLevel, string message);
    }
}
