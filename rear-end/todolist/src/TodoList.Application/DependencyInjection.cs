using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TodoList.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // 省略其他...
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
