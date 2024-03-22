using Lister.Library.Models;

namespace Lister.Application.DTOs.ToDoItems;

public class ToDoAddDto
{
    public string Title { get; set; } = "";

    public string Description { get; set; } = "";

    public DateTime? DueDate { get; set; }

    public int? ToDoListId { get; set; }
}
