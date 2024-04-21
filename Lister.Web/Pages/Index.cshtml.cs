using Lister.Web.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lister.Web.Pages;

[ValidateAntiForgeryToken]
public class IndexModel : PageModel
{
    private ToDoService _todos;

    public IndexModel(ToDoService todos)
    {
        _todos = todos;
    }

    public List<ToDo> AllToDos { get; set; } = [];

    [BindProperty(SupportsGet = true)]
    public string NewToDo { get; set; } = "";

    public IActionResult OnGet()
    {
        AllToDos = _todos.GetAllToDos();

        return Page();
    }

    public IActionResult OnPostComplete(int id)
    {
        _todos.CompleteToDo(id);

        return RedirectToPage();
    }

    public IActionResult OnPostAdd()
    {
        _todos.AddToDo(NewToDo);
        return RedirectToPage();
    }
}
