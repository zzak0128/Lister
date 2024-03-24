using Lister.Application.DTOs.ToDoItems;
using Lister.Application.DTOs.ToDoLists;
using Lister.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lister.Web.Pages.Items
{
    public class DetailModel : PageModel
    {
        private readonly ToDoItemService _todoItems;
        private readonly ToDoListService _listService;

        public DetailModel(ToDoItemService todoItems, ToDoListService listService)
        {
            _todoItems = todoItems;
            _listService = listService;
        }

        [BindProperty(SupportsGet = true)]
        public ToDoDetailDto DetailToDo { get; set; }

        public List<ToDoListDisplayDto> Lists { get; set; } = [];


        public async Task<IActionResult> OnGetAsync(int id)
        {
            DetailToDo = await _todoItems.GetToDoItemByIdAsync(id);
            Lists = await _listService.GetAllAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostUpdateToDoAsync()
        {
            await _todoItems.UpdateItemAsync(DetailToDo);

            return RedirectToPage(new { DetailToDo.Id });
        }
    }
}
