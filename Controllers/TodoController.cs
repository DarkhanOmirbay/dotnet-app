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
    [HttpGet]
    public IActionResult GetTodoById(int id)
    
    {
        return Ok();
    }
}