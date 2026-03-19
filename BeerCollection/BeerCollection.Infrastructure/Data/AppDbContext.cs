using Microsoft.EntityFrameworkCore;
using BeerCollection.Domain.Entities;

namespace BeerCollection.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Beer> Beers { get; set; }
}