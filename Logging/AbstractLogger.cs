using System.ComponentModel.DataAnnotations;

internal enum LoggerLevel
{
    Info = 1,
    Error = 2,
    Debug = 3,
}


internal abstract class AbstractLogger
{
    protected LoggerLevel levels;
    private AbstractLogger _nextLevelLogger;

    public void SetNextLevelLogger(AbstractLogger nextLevelLogger)
    {
        _nextLevelLogger = nextLevelLogger;
    }

    public void LogMessage(LoggerLevel level, string msg, LoggerTarget loggerTarget)
    {
        if (levels == level)
        {
            Display(msg, loggerTarget);
        }

        if (_nextLevelLogger != null)
        {
            _nextLevelLogger.LogMessage(level, msg, loggerTarget);
        }
    }

    protected abstract void Display(string msg, LoggerTarget loggerTarget);
}