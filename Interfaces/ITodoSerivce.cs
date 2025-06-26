using MyApi.Models;
namespace MyApi.Interfaces;

public interface ITodoService
{
    TodoItem AddTodo(CreateTodoDto dto);
}