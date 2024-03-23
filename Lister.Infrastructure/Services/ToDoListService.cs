using System.Security.Cryptography.X509Certificates;
using Lister.Application.DTOs.ToDoLists;
using Lister.Application.Exceptions;
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
            }).OrderBy(x => x.Title).ToListAsync();

        return toDoLists;
    }
    public async Task<ToDoListDisplayDto> GetListByIdAsync(int id)
    {
        ToDoList toDoList = await _context.ToDoLists
            .Include(x => x.ToDoItems.OrderBy(x => x.State))
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        if (toDoList is null)
        {
            throw new InvalidIdException(id);
        }

        ToDoListDisplayDto listDto = new () 
        {
            Id = toDoList.Id,
            Title = toDoList.Title,
            DateCreated = toDoList.DateCreated,
            ToDoItems = toDoList.ToDoItems
        };

        return listDto;
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
