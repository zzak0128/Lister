using Lister.Library.Enums;
using Lister.Library.Models;

namespace Lister.Application.DTOs.ToDoItems;

public class ToDoDisplayDto
{
    public int Id { get; set; }

    public string Title { get; set; } = "";

    public string? Description { get; set; }

    public ItemState State { get; set; }

    public DateTime? DueDate { get; set; }

    public virtual ToDoList? ToDoList { get; set; }
}
