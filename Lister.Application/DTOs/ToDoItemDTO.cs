using Lister.Library.Enums;
using Lister.Library.Models;

namespace Lister.Application.DTOs;

public class ToDoItemDTO
{
    public int Id { get; set; }

    public string Title { get; set; } = "";

    public string Description { get; set; } = "";

    public ItemState State { get; set; } = ItemState.ToDo;

    public ToDoList ToDoList { get; set; }
}
