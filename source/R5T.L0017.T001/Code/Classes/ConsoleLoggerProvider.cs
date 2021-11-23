using System;

using Microsoft.Extensions.Logging;

using R5T.T0087;


namespace R5T.L0017.T001
{
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        #region Static

        private static IConsole OutputConsole { get; }
        private static IConsole ErrorConsole { get; }

        static ConsoleLoggerProvider()
        {
            ConsoleLoggerProvider.OutputConsole = Instances.ConsoleOperator.GetOperatingSystemSpecificConsole();
            ConsoleLoggerProvider.ErrorConsole = Instances.ConsoleOperator.GetOperatingSystemSpecificConsole(true);
        }

        #endregion


        public ILogger CreateLogger(string categoryName)
        {
            var output = new ConsoleLogger(
                categoryName,
                ConsoleLoggerProvider.OutputConsole,
                ConsoleLoggerProvider.ErrorConsole);

            return output;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
