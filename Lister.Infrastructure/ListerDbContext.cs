using Lister.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Lister.Infrastructure;

public class ListerDbContext : DbContext
{
    public DbSet<ToDoItem> ToDoItems { get; set; }

    public DbSet<ToDoList> ToDoLists { get; set; }

    public ListerDbContext(DbContextOptions<ListerDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
    }
}
