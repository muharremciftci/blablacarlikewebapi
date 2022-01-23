

using Microsoft.EntityFrameworkCore;

namespace muharrem
{
    public class TravelDbContext : DbContext
    {
public TravelDbContext(DbContextOptions<TravelDbContext> options)
         : base(options)
        { }
public DbSet<Travel> Travels { get; set; }

    }
}