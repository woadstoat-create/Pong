using System;

internal class ErrorLogger : AbstractLogger
{
    public ErrorLogger(LoggerLevel levels)
    {
        this.levels = levels;
    }

    protected override void Display(string msg, LoggerTarget loggerTarget)
    {
        Console.WriteLine("ERROR: " + msg);
    }
}