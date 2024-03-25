using Lister.Application.DTOs.ToDoItems;
using Lister.Application.Exceptions;
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

    public async Task<List<ToDoTableDto>> GetTableViewItems()
    {
        List<ToDoTableDto> todos = await _context.ToDoItems
            .OrderByDescending(x => x.IsCompleted)
            .OrderBy(x => x.Title)
            .Select(x => new ToDoTableDto
        {
            Id = x.Id,
            Title = x.Title,
            IsCompleted = x.IsCompleted,
            IsPriority = x.IsPriority,
        }).ToListAsync();

        return todos;
    }

    public async Task<ToDoDetailDto> GetToDoItemByIdAsync(int id)
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

        ToDoDetailDto dto = new()
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            DueDate = todo.DueDate,
            IsCompleted = todo.IsCompleted,
            IsPriority = todo.IsPriority,
            DateCreated = todo.DateCreated,
            ToDoList = todo.ToDoList
        };

        return dto;
    }

    public async Task AddToDoItemAsync(ToDoAddDto dto)
    {
        ToDoList AddList = await _context.ToDoLists.Where(x => x.Id == dto.ToDoListId).FirstOrDefaultAsync();

        ToDoItem todo = new()
        {
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate,
            DateCreated = DateTime.Now,
            IsCompleted = false,
            ToDoList = AddList
        };

        _context.ToDoItems.Add(todo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateItemCompleteAsync(int id)
    {
        ToDoItem itemToUpdate = await _context.ToDoItems.FindAsync(id);
        if (itemToUpdate == null) 
        {
            throw new InvalidIdException(id);
        }

        itemToUpdate.IsCompleted = !itemToUpdate.IsCompleted;
        _context.Update(itemToUpdate);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateItemAsync(ToDoDetailDto item)
    {
        ToDoItem todo = await _context.ToDoItems.FindAsync(item.Id);

        if (todo is null)
        {
            throw new InvalidIdException(item.Id);
        }

        todo.Title = item.Title;
        todo.Description = item.Description;
        todo.DueDate = item.DueDate;
        todo.IsCompleted = item.IsCompleted;
        todo.IsPriority = item.IsPriority;
        todo.ToDoList = item.ToDoList;

        _context.ToDoItems.Update(todo);
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
