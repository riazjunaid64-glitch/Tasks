using Microsoft.EntityFrameworkCore;
using ride_sharing_api.Data;
using ride_sharing_api.Entities;
using ride_sharing_api.Enums;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("RideDb"));

var app = builder.Build();

// Seed Data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Users
    var user1 = new User { Name = "Ali", Email = "ali@mail.com" };
    var user2 = new User { Name = "Sara", Email = "sara@mail.com" };

    db.Users.AddRange(user1, user2);

    // Driver
    var driver = new Driver
    {
        User = user2,
        LicenseNumber = "LIC123",
        Rating = 4.8,
        Status = "online"
    };

    db.Drivers.Add(driver);

    // Vehicle
    var vehicle = new Vehicle
    {
        Driver = driver,
        PlateNumber = "ABC-123",
        Type = "Car",
        Color = "White"
    };

    db.Vehicles.Add(vehicle);

    // Locations
    var loc1 = new Location { Latitude = 33.6844, Longitude = 73.0479 };
    var loc2 = new Location { Latitude = 33.7000, Longitude = 73.0600 };

    db.Locations.AddRange(loc1, loc2);

    // Ride
    var ride = new Ride
    {
        Rider = user1,
        Driver = driver,
        Vehicle = vehicle,
        PickupLocation = loc1,
        DropoffLocation = loc2,
        Fare = 500,
        Status = RideStatus.Completed
    };

    db.Rides.Add(ride);

    db.SaveChanges();
}

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();