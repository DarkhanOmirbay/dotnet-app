namespace MyApi.Models;


public class UpdateTodoDto
{
    public String title { get; set; } = String.Empty;
    public bool IsCompleted { get; set; } = false;
}