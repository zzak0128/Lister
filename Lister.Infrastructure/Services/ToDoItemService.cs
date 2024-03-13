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

    public async Task<List<ToDoItem>> GetAllAsync()
    {
        return await _context.ToDoItems.OrderBy(x => x.Title).ToListAsync();
    }

    public async Task<ToDoItem> GetToDoItemByIdAsync(int id, CancellationToken cancellationToken)
    {
        ToDoItem? output = null;
        try
        {
            output = await _context.ToDoItems.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        }
        catch (MySqlException)
        {
            Console.WriteLine($"Unable to connect to the MySql Database.");
        }

        if (output == null)
        {
            throw new InvalidIdException(id);
        }

        return output;
    }

    public async Task AddToDoItem(ToDoItem item)
    {
        _context.ToDoItems.Add(item);
        await _context.SaveChangesAsync();
    }
}
