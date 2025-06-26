using MyApi.Models;
namespace MyApi.Interfaces;

public interface ITodoService
{
    List<TodoItem> GetAllTodos();
    TodoItem AddTodo(CreateTodoDto dto);
    TodoItem? GetTodoById(int id);
    TodoItem? UpdateTodo(int id, UpdateTodoDto dto);
    TodoItem? PatchTodoIsCompleted(int id, PatchTodoDto dto);
    bool DeleteTodo(int id);
}