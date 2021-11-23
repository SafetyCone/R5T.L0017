using System;

using Microsoft.Extensions.Logging;

using R5T.T0086;
using R5T.T0087;


namespace R5T.L0017.X002
{
    public static class ILoggerOperatorExtensions
    {
        public static ConsoleLogMessage GetConsoleLogMessage(this ILoggerOperator _,
            LogLevel logLevel, string logName, int eventId, string message, Exception exception)
        {
            var logLevelColors = Instances.LogLevelOperator.GetLogLevelConsoleColors(logLevel);
            var logLevelString = Instances.LogLevelOperator.GetLogLevelShortName(logLevel);

            var hasLevel = !string.IsNullOrEmpty(logLevelString);
            string timestampFormat = null;
            var logToStandardErrorThreshold = LogLevel.None;
            ConsoleColor? defaultConsoleColor = null;

            // Without log level since the console will apply a color to the log level.
            var messageText = _.GetLogMessageTextWithoutLogLevel(
                logName, eventId, message, exception);

            // Queue log message
            var output = new ConsoleLogMessage()
            {
                TimeStamp = timestampFormat != null ? DateTime.Now.ToString(timestampFormat) : null,
                MessageText = messageText,
                MessageColor = defaultConsoleColor,
                LevelString = hasLevel ? logLevelString : null,
                LevelBackground = hasLevel ? logLevelColors.Background : null,
                LevelForeground = hasLevel ? logLevelColors.Foreground : null,
                LogAsError = logLevel >= logToStandardErrorThreshold
            };

            return output;
        }

        public static void WriteLogMessageEntry(this ILoggerOperator _,
            IConsole outputConsole,
            IConsole errorConsole,
            ConsoleLogMessage message)
        {
            using var consoleExclusiveUsageContext = Instances.Console.GetExclusiveUsageContext();

            var console = message.LogAsError
                ? errorConsole
                : outputConsole
                ;

            if (message.TimeStamp != null)
            {
                console.Write(message.TimeStamp, message.MessageColor, message.MessageColor);
            }

            if (message.LevelString != null)
            {
                console.Write(message.LevelString, message.LevelBackground, message.LevelForeground);
            }

            console.Write(message.MessageText, message.MessageColor, message.MessageColor);
            console.Flush();
        }
    }
}
