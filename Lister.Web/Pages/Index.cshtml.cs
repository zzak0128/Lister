using Lister.Application.DTOs.ToDoItems;
using Lister.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lister.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ToDoItemService _todoItems;

        public IndexModel(ToDoItemService todoItems)
        {
            _todoItems = todoItems;
        }

        public List<ToDoDisplayDto> ToDoItems { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ToDoItems = await _todoItems.GetAllAsync();

            return Page();
        }
    }
}
