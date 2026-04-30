namespace ride_sharing_api.Entities;

public class Driver
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string LicenseNumber { get; set; } = null!;

    public double Rating { get; set; }

    public string Status { get; set; } = "offline";

    public User User { get; set; } = null!;
    
    public List<Vehicle> Vehicles { get; set; } = new();
}