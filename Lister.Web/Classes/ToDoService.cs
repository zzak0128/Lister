namespace Lister.Web.Classes;

public class ToDoService
{
    private List<ToDo> ToDos { get; set; }

    public ToDoService()
    {
        ToDos = [];
    }

    public void AddToDo(string title)
    {
        ToDo addToDo = new(title);
        if (ToDos.Count > 0)
        {
            addToDo.Id = ToDos.Max(x => x.Id) + 1;
        }
        else {
            addToDo.Id = 1;
        }

        ToDos.Add(addToDo);
    }

    public void CompleteToDo(int id)
    {
        ToDo todoUpdate = ToDos.Find(x => x.Id == id)!;
        if (todoUpdate != null)
        {
            todoUpdate.IsComplete = true;
        }
    }

    public void DeleteToDo(ToDo toDo)
    {
        ToDos.Remove(toDo);
    }

    public List<ToDo> GetAllToDos()
    {
        return ToDos;
    }
}
