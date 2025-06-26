namespace MyApi.Services;

using MyApi.Interfaces;
using MyApi.Models;
public class TodoService : ITodoService
{
    private readonly List<TodoItem> _todos = new();
    private int _nextId = 1;

    public TodoItem AddTodo(CreateTodoDto dto)
    {
        var todo = new TodoItem
        {
            Id = _nextId++,
            Title = dto.Title
        };

        _todos.Add(todo);
        return todo;
    }
   
}