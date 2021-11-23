using System;

using R5T.T0086;
using R5T.T0088;


namespace R5T.L0017.X002
{
    public static class Instances
    {
        public static IConsole Console { get; } = T0088.Console.Instance;
        public static ILogLevelOperator LogLevelOperator { get; } = T0086.LogLevelOperator.Instance;
    }
}
