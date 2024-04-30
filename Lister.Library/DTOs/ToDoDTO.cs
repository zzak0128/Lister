namespace Lister.Library.DTOs;

public class ToDoDTO
{
    public string Title { get; set; }

    public bool IsCompleted { get; set; }

    public ToDoDTO(string title, bool isCompleted)
    {
        IsCompleted = isCompleted;
        Title = title;
    }
}
