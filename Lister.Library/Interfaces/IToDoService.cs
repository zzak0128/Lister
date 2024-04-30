using Lister.Library.Models;

namespace Lister.Library.Interfaces
{
    public interface IToDoService
    {
        void AddToDo(string title);
        void CompleteToDo(int id);
        void DeleteToDo(ToDoModel toDo);
        List<ToDoModel> GetAllToDos();
    }
}