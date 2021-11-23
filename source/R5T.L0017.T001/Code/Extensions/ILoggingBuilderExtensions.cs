using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.Console;


namespace R5T.L0017.T001
{
    public static class ILoggingBuilderExtensions
    {
        public static ILoggingBuilder AddConsoleSynchronous(this ILoggingBuilder loggingBuilder)
        {
            loggingBuilder.AddConfiguration();

            loggingBuilder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, ConsoleLoggerProvider>());
            LoggerProviderOptions.RegisterProviderOptions<ConsoleLoggerOptions, ConsoleLoggerProvider>(loggingBuilder.Services);

            return loggingBuilder;
        }
    }
}
