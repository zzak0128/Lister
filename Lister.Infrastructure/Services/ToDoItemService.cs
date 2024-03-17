using Lister.Application.DTOs.ToDoItems;
using Lister.Application.Exceptions;
using Lister.Library.Enums;
using Lister.Library.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace Lister.Infrastructure.Services;

public class ToDoItemService
{
    private readonly ListerDbContext _context;

    public ToDoItemService(ListerDbContext context)
    {
        _context = context;
    }

    public async Task<List<ToDoDisplayDto>> GetAllAsync()
    {
        List<ToDoDisplayDto> todos = await _context.ToDoItems
            .OrderBy(x => x.Title)
            .Select(x => new ToDoDisplayDto
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            State = x.State,
            DueDate = x.DueDate,
            DateCreated = x.DateCreated,
            ToDoList = x.ToDoList
        }).ToListAsync();

        return todos;
    }

    public async Task<List<ToDoDisplayDto>> GetAllOfStateAsync(ItemState state)
    {
        List<ToDoDisplayDto> todos = await _context.ToDoItems
            .OrderBy(x => x.Title)
            .Where(x => x.State == state)
            .Select(x => new ToDoDisplayDto
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            State = x.State,
            DueDate = x.DueDate,
            DateCreated = x.DateCreated,
            ToDoList = x.ToDoList
        }).ToListAsync();

        return todos;
    }

    public async Task<ToDoDisplayDto> GetToDoItemByIdAsync(int id)
    {
        ToDoItem? todo = null;
        try
        {
            todo = await _context.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);
        }
        catch (MySqlException)
        {
            Console.WriteLine($"Unable to connect to the MySql Database.");
        }

        if (todo == null)
        {
            throw new InvalidIdException(id);
        }

        ToDoDisplayDto dto = new()
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            DueDate = todo.DueDate,
            State = todo.State,
            DateCreated = todo.DateCreated,
            ToDoList = todo.ToDoList
        };

        return dto;
    }

    public async Task AddToDoItemAsync(ToDoAddDto dto)
    {
        ToDoItem todo = new()
        {
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate,
            DateCreated = DateTime.Now,
            State = ItemState.ToDo,
            ToDoList = dto.ToDoList
        };

        _context.ToDoItems.Add(todo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateItemStatusAsync(int id, ItemState state)
    {
        ToDoItem itemToUpdate = await _context.ToDoItems.FindAsync(id);
        if (itemToUpdate == null) 
        {
            throw new InvalidIdException(id);
        }

        itemToUpdate.State = state;
        _context.Update(itemToUpdate);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteItemAsync(int id)
    {
        ToDoItem deleteTodo = await _context.ToDoItems.FindAsync(id);

        if (deleteTodo == null) 
        {
            throw new InvalidIdException(id);
        }

        _context.ToDoItems.Remove(deleteTodo);
        await _context.SaveChangesAsync();
    }
}
