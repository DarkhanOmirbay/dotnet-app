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
    [HttpGet]
    public IActionResult GetAllTodos()
    {
        var todos = _todoService.GetAllTodos();
        return Ok(todos);
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
    [HttpPut("{id}")]
    public IActionResult UpdateTodo(int id, [FromBody] UpdateTodoDto dto)
    {
        var updated = _todoService.UpdateTodo(id, dto);
        if (updated == null)
        {
            return NotFound($"Todo with id {id} not found!");
        }
        return Ok(updated);
    }
    [HttpPatch("{id}")]
    public IActionResult PatchIsCompleted(int id, [FromBody] PatchTodoDto dto)
    {
        var updated = _todoService.PatchTodoIsCompleted(id, dto);
        if (updated == null)
        {
            return NotFound($"Todo with id {id} not found!");
        }
        return Ok(updated); // 200 Ok
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteTodo(int id)
    {
        var deleted = _todoService.DeleteTodo(id);
        if (!deleted) {
            return NotFound($"Todo with id {id} not found!");
        }
        return NoContent(); // 204 http
    }

    
}