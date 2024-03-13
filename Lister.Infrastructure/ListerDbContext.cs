using Microsoft.EntityFrameworkCore;

namespace Lister.Infrastructure;

public class ListerDbContext : DbContext
{
    public ListerDbContext(DbContextOptions<ListerDbContext> options) : base(options)
    {
    }
}
