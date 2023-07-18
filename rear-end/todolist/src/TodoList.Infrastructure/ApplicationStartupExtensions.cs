using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Infrastructure.Persistence;

namespace TodoList.Infrastructure;

public static class ApplicationStartupExtensions
{
    public static void MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<TodoListDbContext>();
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred migrating the DB: {ex.Message}");
        }
    }
}
