using System;

using Microsoft.Extensions.Logging;

using R5T.T0064;


namespace R5T.L0017.D001
{
    /// <summary>
    /// Dummy service definition for the unbound service <see cref="ILogger{TCategoryName}"/>.
    /// </summary>
    [ServiceDefinitionMarker]
    [UnboundGenericServiceDefinitionMarker(typeof(ILogger<>))]
    public interface ILoggerUnbound : IServiceDefinition, IUnboundGenericServiceDefinition
    {
    }
}
