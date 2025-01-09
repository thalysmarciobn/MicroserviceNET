using System.Reflection;
using Common.CQRS;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommandHandlersFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        var handlerInterfaceType = typeof(ICommandHandler<,>);

        var handlerTypes = assembly.GetTypes()
            .Where(type => type is { IsAbstract: false, IsInterface: false })
            .SelectMany(type => type.GetInterfaces(), (type, iface) => new { type, iface })
            .Where(t => t.iface.IsGenericType && t.iface.GetGenericTypeDefinition() == handlerInterfaceType)
            .ToList();

        foreach (var handler in handlerTypes) services.AddTransient(handler.iface, handler.type);

        return services;
    }
}