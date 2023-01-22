namespace Logger
{
    public abstract class BaseLogger
    {
        private string? _FilePath;
        public string FilePath { get => _FilePath!; set => _FilePath = value; }

        private string? _ClassName;

        public string ClassName { get => _ClassName!; set => _ClassName = value; }

        public abstract void Log(LogLevel logLevel, string message);
    }
}
