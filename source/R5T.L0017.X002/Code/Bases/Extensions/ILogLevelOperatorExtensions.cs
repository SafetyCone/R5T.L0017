using System;

using Microsoft.Extensions.Logging;

using R5T.T0086;


namespace R5T.L0017.X002
{
    public static class ILogLevelOperatorExtensions
    {
        public static ConsoleColors GetLogLevelConsoleColors(this ILogLevelOperator _, LogLevel logLevel,
            bool disableColors = false,
            ConsoleColor? defaultConsoleColor = null)
        {
            if (disableColors)
            {
                return new ConsoleColors(null, null);
            }

            var output = logLevel switch
            {
                LogLevel.Critical => new ConsoleColors(ConsoleColor.White, ConsoleColor.Red),
                LogLevel.Error => new ConsoleColors(ConsoleColor.Black, ConsoleColor.Red),
                LogLevel.Warning => new ConsoleColors(ConsoleColor.Yellow, ConsoleColor.Black),
                LogLevel.Information => new ConsoleColors(ConsoleColor.DarkGreen, ConsoleColor.Black),
                LogLevel.Debug => new ConsoleColors(ConsoleColor.Gray, ConsoleColor.Black),
                LogLevel.Trace => new ConsoleColors(ConsoleColor.Gray, ConsoleColor.Black),
                _ => new ConsoleColors(defaultConsoleColor, defaultConsoleColor),
            };

            return output;
        }
    }
}
