namespace Lister.Application.DTOs.ToDoItems;

public class ToDoTableDto
{
    public int Id { get; set; }

    public string Title { get; set; } = "";

    public bool IsCompleted { get; set; }

    public bool IsPriority { get; set; }
}
