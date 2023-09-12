using MediatR;
using TodoList.Application.Common.Interfaces;

namespace TodoList.Application.TodoLists.Commands.CreateTodoList;

public class CreateTodoListCommand : IRequest<Guid>
{
    public string? Title { get; set; }
}

public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, Guid>
{
    private readonly IRepository<Domain.Entities.TodoList> _repository;

    public CreateTodoListCommandHandler(IRepository<Domain.Entities.TodoList> repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.TodoList
        {
            Title = request.Title
        };

        await _repository.AddAsync(entity, cancellationToken);
        return entity.Id;
    }
}
