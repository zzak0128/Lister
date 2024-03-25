using Lister.Application.DTOs.ToDoItems;
using Lister.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lister.Web.Pages.Components.ToDoTableView
{
    public class ToDoTableViewViewComponent : ViewComponent
    {
        private readonly ToDoItemService _todoItems;

        public ToDoTableViewViewComponent(ToDoItemService todoItems)
        {
            _todoItems = todoItems;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ToDoTableDto> todos = [];

            todos = await _todoItems.GetTableViewItems();

            return View(todos);
        }
    }
}
