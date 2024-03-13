
namespace Lister.Library.Models;

public class ToDoList
{
    public int Id { get; set; }

    public string Title { get; set; } = "";

    public DateTime DateCreated { get; set; } = DateTime.Now;

    public virtual List<ToDoItem> ToDoItems { get; set; } = [];
}
