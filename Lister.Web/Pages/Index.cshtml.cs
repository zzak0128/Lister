using Lister.Application.DTOs.ToDoItems;
using Lister.Application.DTOs.ToDoLists;
using Lister.Infrastructure.Services;
using Lister.Library.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lister.Web.Pages
{
    [ValidateAntiForgeryToken]
    public class IndexModel : PageModel
    {
        private readonly ToDoItemService _todoItems;
        private readonly ToDoListService _todoLists;

        public IndexModel(ToDoItemService todoItems, ToDoListService todoLists)
        {
            _todoItems = todoItems;
            _todoLists = todoLists;
        }

        [BindProperty(SupportsGet = true)]    
        public ToDoAddDto NewToDo { get; set; }

        public List<ToDoDisplayDto> ToDoItems { get; set; }

        public List<ToDoListDisplayDto> Lists { get; set; } = [];

        public async Task<IActionResult> OnGetAsync()
        {
            ToDoItems = await _todoItems.GetAllAsync();
            Lists = await _todoLists.GetAllAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostSaveTodoAsync()
        {
            await _todoItems.AddToDoItemAsync(NewToDo);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _todoItems.DeleteItemAsync(id);

            return ViewComponent(nameof(Components.ToDoTableView));
        }

        public async Task<IActionResult> OnPostUpdateStatusAsync(int id, ItemState state)
        {
            await _todoItems.UpdateItemStatusAsync(id, state);

            return ViewComponent(nameof(Components.ToDoTableView));
        }
    }
}
