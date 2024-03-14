using Lister.Application.DTOs.ToDoLists;
using Lister.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Lister.Infrastructure.Services;

public class ToDoListService
{
    private readonly ListerDbContext _context;

    public ToDoListService(ListerDbContext context)
    {
        _context = context;
    }

    public async Task<List<ToDoListDisplayDto>> GetAllAsync()
    {
        List<ToDoListDisplayDto> toDoLists = [];

        toDoLists = await _context.ToDoLists
            .Include(x => x.ToDoItems)
            .OrderBy(x => x.Title)
            .Select(x => new ToDoListDisplayDto
            {
                Id = x.Id,
                Title = x.Title,
                DateCreated = DateTime.Now,
                ToDoItems = x.ToDoItems
            }).ToListAsync();

        return toDoLists;
    }

    public async Task AddToDoList(ToDoListAddDto dto)
    {
        ToDoList list = new()
        {
            Title = dto.Title,
            DateCreated = DateTime.Now
        };

        _context.ToDoLists.Add(list);
        await _context.SaveChangesAsync();
    }
}
