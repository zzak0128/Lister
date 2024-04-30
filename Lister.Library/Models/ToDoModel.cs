namespace Lister.Library.Models;

public class ToDoModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public bool IsComplete { get; set; } = false;

    public ToDoModel(string title)
    {
        Title = title;
    }
}
