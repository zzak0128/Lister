using Lister.Application.DTOs.ToDoLists;
using Lister.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lister.Web.Pages.Lists
{
    public class AllListsModel : PageModel
    {
        private readonly ToDoListService _lists;
        public AllListsModel(ToDoListService lists)
        {
            _lists = lists;
        }

        public List<ToDoListDisplayDto> ToDoLists { get; set; }

        [BindProperty(SupportsGet = true)]
        public ToDoListAddDto AddList { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            ToDoLists = await _lists.GetAllAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostSaveListAsync()
        {
            await _lists.AddToDoList(AddList);

            return RedirectToPage();
        }

    }
}
