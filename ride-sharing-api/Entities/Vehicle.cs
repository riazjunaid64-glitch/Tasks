namespace ride_sharing_api.Entities;

public class Vehicle
{
    public int Id { get; set; }

    public int DriverId { get; set; }
    public Driver Driver { get; set; } = null!;

    public string PlateNumber { get; set; } = null!;
    public string Type { get; set; } = null!;   // Car, Bike
    public string Color { get; set; } = null!;
}