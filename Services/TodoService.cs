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
    public TodoItem? GetTodoById(int id)
    {
        return _todos.FirstOrDefault(element => element.Id == id);
    }
    public TodoItem? UpdateTodo(int id, UpdateTodoDto dto)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo == null) return null;

        todo.Title = dto.title;
        todo.IsCompleted = dto.IsCompleted;
        return todo;
    }
   
}