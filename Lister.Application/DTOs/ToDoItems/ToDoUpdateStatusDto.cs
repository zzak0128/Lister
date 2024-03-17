using Lister.Library.Enums;

namespace Lister.Application;

public class ToDoUpdateStatusDto
{
    public int Id { get; set; }

    public ItemState State { get; set; }
}
