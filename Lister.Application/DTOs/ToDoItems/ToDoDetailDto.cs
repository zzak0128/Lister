using Lister.Library.Models;

namespace Lister.Application.DTOs.ToDoItems;

public class ToDoDetailDto
{
     public int Id { get; set; }

    public string Title { get; set; } = "";

    public string? Description { get; set; }

    public bool IsCompleted { get; set; }

    public bool IsPriority { get; set; }

    public DateTime? DueDate { get; set; }

    public DateTime DateCreated { get; set; }

    public virtual ToDoList? ToDoList { get; set; }
}
