namespace MyApi.Models;

public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public bool IsCompleted { get; set; } = false;
}