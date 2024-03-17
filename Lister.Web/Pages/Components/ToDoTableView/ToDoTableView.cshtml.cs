using Lister.Application.DTOs.ToDoItems;
using Lister.Infrastructure.Services;
using Lister.Library.Enums;
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

        public async Task<IViewComponentResult> InvokeAsync(ItemState? state)
        {
            List<ToDoDisplayDto> todos = [];

            if (state.HasValue)
            {
                todos = await _todoItems.GetAllOfStateAsync(state.Value);
            }
            else
            {
                todos = await _todoItems.GetAllAsync();
            }


            return View(todos);
        }
    }
}
