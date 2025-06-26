namespace MyApi.Services;

using MyApi.Interfaces;
using MyApi.Models;
public class TodoService : ITodoService
{
    private readonly List<TodoItem> _todos = new();
    private int _nextId = 1;
    public List<TodoItem> GetAllTodos() => _todos;

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
    public TodoItem? PatchTodoIsCompleted(int id, PatchTodoDto dto)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id); // lambda function t => t.id == id;
        if (todo == null)
        {
            return null;
        }
        if (dto.IsCompleted.HasValue)
        {
            todo.IsCompleted = dto.IsCompleted.Value;
        }
        return todo;
    }
    public bool DeleteTodo(int id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return false;
        }
        _todos.Remove(todo);
        return true;
    }
   
}