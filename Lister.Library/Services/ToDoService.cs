using Lister.Library.Interfaces;
using Lister.Library.Models;

namespace Lister.Library.Services;

public class ToDoService : IToDoService
{
    private List<ToDoModel> ToDos { get; set; }

    public ToDoService()
    {
        ToDos = [];
        ToDos = PopulateData();
    }

    private List<ToDoModel> PopulateData()
    {
        AddToDo("Item 1");
        AddToDo("Item 2");
        AddToDo("Item 3");
        AddToDo("Item 4");

        return ToDos;
    }

    public void AddToDo(string title)
    {
        ToDoModel addToDo = new(title);
        if (ToDos.Count > 0)
        {
            addToDo.Id = ToDos.Max(x => x.Id) + 1;
        }
        else
        {
            addToDo.Id = 1;
        }

        ToDos.Add(addToDo);
    }

    public void CompleteToDo(int id)
    {
        ToDoModel todoUpdate = ToDos.Find(x => x.Id == id)!;
        if (todoUpdate != null)
        {
            todoUpdate.IsComplete = true;
        }
    }

    public void DeleteToDo(ToDoModel toDo)
    {
        ToDos.Remove(toDo);
    }

    public List<ToDoModel> GetAllToDos()
    {
        return ToDos;
    }
}
