using Lister.Library.Interfaces;
using Lister.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lister.Web.Pages;

[ValidateAntiForgeryToken]
public class IndexModel : PageModel
{
    private IToDoService _todos;

    public IndexModel(IToDoService todos)
    {
        _todos = todos;
    }

    public List<ToDoModel> AllToDos { get; set; } = [];

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
