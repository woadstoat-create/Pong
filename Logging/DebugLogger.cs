using System;

internal class DebugLogger : AbstractLogger
{
    public DebugLogger(LoggerLevel levels)
    {
        this.levels = levels;
    }

    protected override void Display(string msg, LoggerTarget loggerTarget)
    {
        Console.WriteLine("DEBUG: " + msg);   
    }

}