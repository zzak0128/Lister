using Lister.Application.DTOs.ToDoItems;
using Lister.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lister.Web.Pages
{
    [ValidateAntiForgeryToken]
    public class IndexModel : PageModel
    {
        private readonly ToDoItemService _todoItems;

        public IndexModel(ToDoItemService todoItems)
        {
            _todoItems = todoItems;
        }

        [BindProperty(SupportsGet = true)]    
        public ToDoAddDto NewToDo { get; set; }

        public List<ToDoDisplayDto> ToDoItems { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ToDoItems = await _todoItems.GetAllAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostSaveTodoAsync()
        {
            await _todoItems.AddToDoItemAsync(NewToDo);

            return RedirectToPage();
        }
    }
}
