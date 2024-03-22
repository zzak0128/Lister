using Lister.Application.DTOs.ToDoItems;
using Lister.Infrastructure.Services;
using Lister.Library.Enums;
using Lister.Library.Models;
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

        public async Task<IViewComponentResult> InvokeAsync(ItemState? state, ToDoList? todoList)
        {
            List<ToDoDisplayDto> todos = [];

            if (state.HasValue)
            {
                if (todoList is null)
                {
                    todos = await _todoItems.GetAllOfStateAsync(state.Value);
                }
                else
                {
                    todos = await _todoItems.GetAllOfStateAsync(state.Value, todoList);
                }
            }
            else
            {
                if (todoList is null)
                {
                    todos = await _todoItems.GetAllActiveAsync();
                }
                else
                {
                    todos = await _todoItems.GetAllActiveAsync(todoList);
                }
            }

            return View(todos);
        }
    }
}
