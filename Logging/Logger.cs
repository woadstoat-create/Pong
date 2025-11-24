using System;
//https://dev.to/ahmedadel/low-level-design-logging-framework-n12
public class Logger
{
    private static Logger _logger;
    private static AbstractLogger _chainOfLogger;
    private Logger()
    {
        if (_logger != null)
            throw new InvalidOperationException("Object already created");
    }

    public static Logger GetLogger()
    {
        if (_logger == null)
        {
            lock (typeof(Logger))
            {
                if (_logger == null)
                {
                    _logger = new Logger();
                    _chainOfLogger = CreateChainOfLogger();
                }
            }
        }
        return _logger;
    }
}