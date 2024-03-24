using Lister.Library.Enums;

namespace Lister.Application.DTOs.ToDoItems;

public class ToDoUpdateStatusDto
{
    public int Id { get; set; }

    public ItemState State { get; set; }
}
