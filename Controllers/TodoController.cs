using Microsoft.AspNetCore.Mvc;
using MyApi.Interfaces;
using MyApi.Models;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }
    [HttpPost]
    public IActionResult CreateTodo([FromBody] CreateTodoDto dto)
    {
        var created = _todoService.AddTodo(dto);
        return CreatedAtAction(nameof(GetTodoById), new { id = created.Id }, created);
    }
    [HttpGet("{id}")]
    public IActionResult GetTodoById(int id)
    
    {
        var todo = _todoService.GetTodoById(id);
        if (todo == null)
            return NotFound($"Todo with id {id} not found!");

        return Ok(todo);
    }
}