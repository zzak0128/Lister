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

    public async Task<List<ToDoList>> GetAll()
    {
        return await _context.ToDoLists.OrderBy(x => x.Title).ToListAsync();
    }
}
