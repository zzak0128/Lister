using Lister.Application.DTOs.ToDoItems;
using Lister.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lister.Web.Pages.Components.ToDoTableView
{
    public class ToDoTableViewComponent : ViewComponent
    {
        private readonly ToDoItemService _todoItems;

        public ToDoTableViewComponent(ToDoItemService todoItems)
        {
            _todoItems = todoItems;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ToDoDisplayDto> todos = await _todoItems.GetAllAsync();

            return View(todos);
        }
    }
}
