using System;
using System.IO;

using Microsoft.Extensions.Logging;


namespace R5T.L0017.X001
{
    public static class ILoggerExtensions
    {
        public static void TestLogLevelOutput(this ILogger logger)
        {
            Instances.LoggerOperator.TestLogLevelOutput(logger);
        }

        public static void TestLogLevelEnabled(this ILogger logger,
            TextWriter textWriter)
        {
            Instances.LoggerOperator.TestLogLevelEnabled(logger, textWriter);
        }

        public static void TestLogLevelEnabled(this ILogger logger,
            TextWriter textWriter,
            LogLevel logLevel)
        {
            Instances.LoggerOperator.TestLogLevelEnabled(logger, textWriter, logLevel);
        }
    }
}