internal class InfoLogger : AbstractLogger
{
    public InfoLogger(LoggerLevel levels)
    {
        this.Levels = levels;
    }

    protected override void Display(string msg, LoggerTarget loggerTarget)
    {
        Console.WriteLine("INFO: " + msg);
    }
}