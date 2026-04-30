namespace ride_sharing_api.Entities;

public class Location
{
    public int Id { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }

    // optional, for future use
    public string? Address { get; set; }
}