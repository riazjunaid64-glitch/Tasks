using ride_sharing_api.Enums;
namespace ride_sharing_api.Entities;

public class Ride
{
    public int Id { get; set; }

    public int RiderId { get; set; }
    public User Rider { get; set; } = null!;

    public int? DriverId { get; set; }
    public Driver? Driver { get; set; }

    public int PickupLocationId { get; set; }
    public int DropoffLocationId { get; set; }

    public decimal Fare { get; set; }

   public RideStatus Status { get; set; } = RideStatus.Requested;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public Location PickupLocation { get; set; } = null!;
    public Location DropoffLocation { get; set; } = null!;

    public Payment? Payment { get; set; }
    public int? VehicleId { get; set; }
    public Vehicle? Vehicle { get; set; }
}