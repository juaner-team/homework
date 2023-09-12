using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.TodoItems.Commands.CreateTodoItem;

namespace TodoList.Api.Controllers;

[ApiController]
[Route("/todo-item")]
public class TodoItemController : ControllerBase
{
    private readonly IMediator _mediator;

    // 注入MediatR
    public TodoItemController(IMediator mediator)
        => _mediator = mediator;

    [HttpPost]
    public async Task<Guid> Create([FromBody] CreateTodoItemCommand command)
    {
        var id = await _mediator.Send(command);

        // 出于演示的目的，这里只返回创建出来的TodoItems的Id，
        // 实际使用中可能会选择IActionResult作为返回的类型并返回CreatedAtRoute对象，
        // 因为我们还没有去写GET方法，返回CreatedAtRoute会报错（找不到对应的Route），等讲完GET后会在那里更新
        return id;
    }
}
