using Lister.Library.Models;
using Microsoft.EntityFrameworkCore;

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
}
