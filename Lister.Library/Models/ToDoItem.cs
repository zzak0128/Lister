namespace Lister.Library.Models;

public class ToDoItem
{
    public int Id { get; set; }

    public string Title { get; set; } = "";

    public string? Description { get; set; }

    public bool IsCompleted { get; set; }

    public bool IsPriority { get; set; }

    public DateTime? DueDate { get; set; }

    public DateTime DateCreated { get; set; } = DateTime.Now;

    public virtual ToDoList? ToDoList { get; set; }
}
