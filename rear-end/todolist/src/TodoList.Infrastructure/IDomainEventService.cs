using TodoList.Domain.Base;

namespace TodoList.Infrastructure;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
