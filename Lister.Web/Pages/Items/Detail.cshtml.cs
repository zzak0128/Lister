using Lister.Application.DTOs.ToDoItems;
using Lister.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lister.Application.DTOs.ToDoLists;

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

        public List<ToDoListDisplayDto> Lists { get; set; } = [];

        [BindProperty(SupportsGet = true)]
        public ToDoDetailDto DetailToDo { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            DetailToDo = await _todoItems.GetToDoItemByIdAsync(id);
            Lists = await _listService.GetAllAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostUpdateToDoAsync()
        {
            var test = DetailToDo;

            await _todoItems.UpdateItemAsync(DetailToDo);

            return RedirectToPage(new { DetailToDo.Id });
        }

        public async Task<IActionResult> OnPostDeleteToDoAsync()
        {


            return RedirectToPage("./AllLists");
        }

    }
}
