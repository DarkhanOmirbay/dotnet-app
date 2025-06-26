using MyApi.Models;
namespace MyApi.Interfaces;

public interface ITodoService
{
    TodoItem AddTodo(CreateTodoDto dto);
    TodoItem? GetTodoById(int id);
    TodoItem? UpdateTodo(int id,UpdateTodoDto dto);
}