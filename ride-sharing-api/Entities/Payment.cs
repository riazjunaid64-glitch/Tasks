namespace ride_sharing_api.Entities;

public class Payment
{
    public int Id { get; set; }

    public int RideId { get; set; }
    public Ride Ride { get; set; } = null!;

    public decimal Amount { get; set; }

    public string Status { get; set; } = "pending";
}