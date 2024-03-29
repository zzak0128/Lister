using Lister.Application.DTOs.ToDoLists;
using Lister.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lister.Web.Pages.Lists
{
    public class ListItemsModel : PageModel
    {
        private readonly ToDoListService _toDoLists;

        public ListItemsModel(ToDoListService toDoLists)
        {
            _toDoLists = toDoLists;
        }

        public ToDoListDisplayDto SelectedList { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            SelectedList = await _toDoLists.GetListByIdAsync(id);

            return Page();
        }
    }
}
