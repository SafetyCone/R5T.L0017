using System;

using Microsoft.Extensions.Logging;

using R5T.T0087;

using R5T.L0017.T002;
using R5T.L0017.X002;


namespace R5T.L0017.T001
{
    /// <summary>
    /// A synchronous console logger.
    /// The <see cref="Microsoft.Extensions.Logging.Console.ConsoleLogger"/> uses an asynchronous queue, which while great for production where speed is of the essence, is bad for debugging, since log messages may not have actually been output by the time a breakpoint is hit (especially in asynchronous code).
    /// </summary>
    /// <remarks>
    /// See: https://github.com/aspnet/Logging/blob/master/src/Microsoft.Extensions.Logging.Console/ConsoleLogger.cs
    /// </remarks>
    public class ConsoleLogger : LoggerBase
    {
        private IConsole OutputConsole { get; }
        private IConsole ErrorConsole { get; }


        public ConsoleLogger(
            string categoryName,
            IConsole outputConsole,
            IConsole errorConsole)
            : base(categoryName)
        {
            this.OutputConsole = outputConsole;
            this.ErrorConsole = errorConsole;
        }

        public override void WriteMessage(LogLevel logLevel, string logName, int eventId, string message, Exception exception)
        {
            var logMessageEntry = Instances.LoggerOperator.GetConsoleLogMessage(logLevel, logName, eventId, message, exception);

            Instances.LoggerOperator.WriteLogMessageEntry(this.OutputConsole, this.ErrorConsole, logMessageEntry);
        }
    }
}
