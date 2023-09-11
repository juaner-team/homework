using Microsoft.Extensions.Logging;
using TodoList.Domain.Base;

namespace TodoList.Infrastructure.Services;

public class DomainEventService : IDomainEventService
{
    private readonly ILogger<DomainEventService> _logger;

    public DomainEventService(ILogger<DomainEventService> logger)
    {
        _logger = logger;
    }

    public async Task Publish(DomainEvent domainEvent)
    {
        // 在这里暂时什么都不做，到CQRS那一篇的时候再回来补充这里的逻辑
        _logger.LogInformation("Publishing domain event. Event - {event}", domainEvent.GetType().Name);
    }
}
