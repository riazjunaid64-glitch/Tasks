using Microsoft.EntityFrameworkCore;
using ride_sharing_api.Entities;

namespace ride_sharing_api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Driver> Drivers => Set<Driver>();
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<Ride> Rides => Set<Ride>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Payment> Payments => Set<Payment>();
}