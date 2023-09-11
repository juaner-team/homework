using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Application.Common.Interfaces;
using TodoList.Infrastructure.Persistence;
using TodoList.Infrastructure.Services;

namespace TodoList.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TodoListDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("SqlServerConnection"),
                b => b.MigrationsAssembly(typeof(TodoListDbContext).Assembly.FullName)));

        // 省略以上...并且这一句可以不需要了
        // services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<TodoListDbContext>());

        // 增加依赖注入
        services.AddScoped<IDomainEventService, DomainEventService>();
        return services;


        return services;
    }
}
