namespace Lister.Web.Classes;

public class ToDo
{
    public int Id { get; set; }

    public string Title { get; set; }

    public bool IsComplete { get; set; } = false;

    public ToDo(string title)
    {
        Title = title;
    }
}
