using Lister.Library.Models;

namespace Lister.Application.DTOs.ToDoLists;

public class ToDoListDisplayDto
{
    public int Id { get; set; }

    public string Title { get; set; } = "";

    public DateTime DateCreated { get; set; }

    public virtual List<ToDoItem> ToDoItems { get; set; } = [];
}
