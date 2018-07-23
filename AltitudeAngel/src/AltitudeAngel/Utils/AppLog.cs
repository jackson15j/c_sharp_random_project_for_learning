using NLog;

/**
   NLog config in a separate class for cross-project importing.
 */
public static class AppLog
{
    /**
       Configures the Console/File logging.

       TODO: make it configurable (log levels, file name).
     */
    public static void ConfigureLogging()
    {
        var config = new NLog.Config.LoggingConfiguration();
        var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "app.log" };
        var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
        config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
        config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
        NLog.LogManager.Configuration = config;
    }
}
